using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimate : EnnemyAnimator
{
    //public enum StunState { ToStun, Stunned, StunToNormal };
    //public StunState stunState;
    protected StunAnimator stunAnimator;
    //protected BossAttackAnimator bossAttackAnimator;

    // Start is called before the first frame update
    void Start()
    {
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
            GameObject projectile = projectileSummonerBehaviour.Summon(0.0f);
            //yield return 0;
            //float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime;
            //Debug.Log("Attack wait : remainingTime = " + remainingTime + " ; length : " + GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length + " *  normalized : " + GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime);
            yield return new WaitForSeconds(1.3f);
            if (state == State.Attack)
            {
                projectile.GetComponent<ProjectileBehaviour>().Throw(10.0f);
                state = State.AttackEnd;
            }
            yield return new WaitForSeconds(0.7f);
        }
        state = State.AttackEnd;
        GoToNextState();
    }

    protected new IEnumerator AttackEndState()
    {
        GetComponent<Animator>().SetLayerWeight(1, 0.0f);
        GetComponent<Animator>().Play("Nothing");
        yield return new WaitForSeconds(cooldownAttack);
        if (state == State.AttackEnd)
            state = State.Attack;
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
            if (stunAnimator.state == StunAnimator.State.Nothing)
            {
                state = State.Idle;
            }
        }
        GoToNextState();
    }

    protected new IEnumerator TransformationState()
    {
        while (state == State.Transformation)
        {
            GetComponent<Animator>().SetLayerWeight(2, 1.0f);
            GetComponent<Animator>().Play("Transformation");
            yield return 5.0f;
            state = State.Idle;
        }
        GetComponent<Animator>().SetLayerWeight(2, 0.0f);
        GoToNextState();
    }

}
