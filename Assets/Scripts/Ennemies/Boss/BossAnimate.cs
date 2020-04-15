using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimate : EnnemyAnimator
{
    //public enum StunState { ToStun, Stunned, StunToNormal };
    //public StunState stunState;
    protected StunAnimator stunAnimator;
    protected BossBehaviour bossBehaviour;

    //protected BossAttackAnimator bossAttackAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bossBehaviour = GetComponent<BossBehaviour>();
        stunAnimator = GetComponent<StunAnimator>();
        projectileSummonerBehaviour = gameObject.GetComponent<ProjectileSummonerBehaviour>();
        //bossAttackAnimator = GetComponent<BossAttackAnimator>();
        //bossAttackAnimator.cooldown = cooldownAttack;
        GoToNextState();
    }


    protected new IEnumerator AttackState()
    {
        GetComponent<Animator>().Play("Idle");
        while (state == State.Attack)
        {
            GetComponent<Animator>().SetLayerWeight(1, 1.0f);
            GetComponent<Animator>().Play("CastFireball");

            if (bossBehaviour.getPhase() == 2)
            {
                GameObject projectile = projectileSummonerBehaviour.Summon(0.0f);
                yield return new WaitForSeconds(1.3f);
                projectile.GetComponent<ProjectileBehaviour>().Throw(10.0f);
            }
            else
                yield return new WaitForSeconds(1.3f);

            bossBehaviour.castAoe();

            if (state == State.Attack)
            {
                Debug.Log("attack TO attackEnd");
                state = State.AttackEnd;
                if (bossBehaviour.getPhase() == 2)
                {
                    bossBehaviour.setInvulnerable();
                }
            }
            yield return new WaitForSeconds(0.7f);
        }
        GoToNextState();
    }

    protected new IEnumerator AttackEndState()
    {
        GetComponent<Animator>().SetLayerWeight(1, 0.0f);
        GetComponent<Animator>().Play("Nothing");
        yield return new WaitForSeconds(cooldownAttack);
        if (state == State.AttackEnd)
        {
            Debug.Log("attackend TO attack");
            state = State.Attack;
        }
        GoToNextState();
    }

    protected new IEnumerator IsHitState()
    {
        if (stunAnimator.state == StunAnimator.State.Nothing)
            stunAnimator.state = StunAnimator.State.IsHit;
        //Debug.Log("IsHitState : " + stunAnimator.state + " // stunstate = "+ stunAnimator.state);
        while (stunAnimator.state != StunAnimator.State.Nothing)
        {
            yield return 0;
            if (stunAnimator.state == StunAnimator.State.Nothing && state == State.IsHit)
            {
                state = State.Idle;
            }
        }
        GoToNextState();
    }

    protected new IEnumerator TransformationState()
    {
        Debug.Log("Transformation00");
        //StopCoroutine(previousCoroutine);
        //StopCoroutine(stunAnimator.currentCoroutine);
        while (state == State.Transformation)
        {
            Debug.Log("transfo");
            GetComponent<Animator>().SetLayerWeight(0, 0.0f);
            GetComponent<Animator>().SetLayerWeight(1, 0.0f);
            GetComponent<Animator>().SetLayerWeight(2, 1.0f);
            GetComponent<Animator>().Play("Transformation");
            yield return new WaitForSeconds(2.3f);
            Debug.Log("fin transfo1");
            if (state == State.Transformation)
            {
            Debug.Log("fin transfo2");
                state = State.Idle;
                GetComponent<Animator>().SetLayerWeight(2, 0.0f);
                GetComponent<Animator>().SetLayerWeight(0, 1.0f);
                GetComponent<Animator>().SetLayerWeight(1, 1.0f);
            }
        }
        GoToNextState();
    }

}
