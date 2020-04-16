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
        damageableAnimator = GetComponent<DamageableAnimator>();
        projectileSummonerBehaviour = gameObject.GetComponent<ProjectileSummonerBehaviour>();
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
                GetComponent<Animator>().SetLayerWeight(1, 0.0f);
                state = State.AttackEnd;
            }
            yield return new WaitForSeconds(0.7f);
        }
        GoToNextState();
    }

    protected new IEnumerator AttackEndState()
    {
        GetComponent<Animator>().Play("Nothing");
        yield return new WaitForSeconds(cooldownAttack);
        if (state == State.AttackEnd)
        {
            state = State.Attack;
        }
        GoToNextState();
    }

    protected new IEnumerator StunState()
    {
        if (stunAnimator.state == StunAnimator.State.Nothing)
            stunAnimator.state = StunAnimator.State.IsHit;
        //Debug.Log("IsHitState : " + stunAnimator.state + " // stunstate = "+ stunAnimator.state);
        while (stunAnimator.state != StunAnimator.State.Nothing)
        {
            yield return 0;
            if (stunAnimator.state == StunAnimator.State.Nothing)
            {
                state = State.Idle;
                if (bossBehaviour.getPhase() == 2 && !bossBehaviour.isDead())
                {
                    bossBehaviour.setInvulnerable();
                }
            }
        }
        GoToNextState();
    }

    protected new IEnumerator TransformationState()
    {
        while (state == State.Transformation)
        {
            GetComponent<Animator>().SetLayerWeight(0, 0.0f);
            GetComponent<Animator>().SetLayerWeight(1, 0.0f);
            GetComponent<Animator>().SetLayerWeight(2, 1.0f);
            GetComponent<Animator>().Play("Transformation");
            yield return new WaitForSeconds(2.3f);
            if (state == State.Transformation)
            {
                state = State.Idle;
                GetComponent<Animator>().SetLayerWeight(2, 0.0f);
                GetComponent<Animator>().SetLayerWeight(0, 1.0f);
                GetComponent<Animator>().SetLayerWeight(1, 1.0f);
            }
        }
        GoToNextState();
    }

}
