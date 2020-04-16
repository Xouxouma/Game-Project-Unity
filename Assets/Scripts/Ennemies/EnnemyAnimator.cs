using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnimator : MonoBehaviour
{
    public enum State { Idle, Chase, Attack, AttackEnd, Transformation, Stun};
    public State state;
    protected ProjectileSummonerBehaviour projectileSummonerBehaviour;
    public float cooldownAttack = 1.0f;
    protected Coroutine currentCoroutine;
    protected Coroutine previousCoroutine;
    protected DamageableAnimator damageableAnimator;

    protected void GoToNextState()
    {
        if (damageableAnimator.state != DamageableAnimator.State.KO)
        {
            Debug.Log("Gotonextstate " + state);
            string methodName = state.ToString() + "State";
            System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            previousCoroutine = currentCoroutine;
            currentCoroutine = StartCoroutine((IEnumerator)info.Invoke(this, null));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        damageableAnimator = GetComponent<DamageableAnimator>();
        projectileSummonerBehaviour = gameObject.GetComponent<ProjectileSummonerBehaviour>();
        GoToNextState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected IEnumerator IdleState()
    {
        while (state == State.Idle)
        {
            Debug.Log("idle");
            GetComponent<Animator>().Play("Idle");
            yield return 0;
        }
        GoToNextState();
    }

    protected IEnumerator TransformationState()
    {
        while (state == State.Transformation)
        {
            GetComponent<Animator>().Play("Transformation");
            yield return 0;
        }
        GoToNextState();
    }

    protected IEnumerator ChaseState()
    {
        while (state == State.Chase)
        {
            GetComponent<Animator>().Play("Chase");
            yield return 0;
        }
        GoToNextState();
    }

    protected IEnumerator AttackState()
    {
        GetComponent<Animator>().SetLayerWeight(1, 1.0f);
        if (projectileSummonerBehaviour != null)
        {
            projectileSummonerBehaviour.Summon();
        }
        while (state == State.Attack)
        {
            Debug.Log("attack");
            GetComponent<Animator>().Play("Attack");
            //yield return 0;
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            if (state == State.Attack)
            {
                state = State.AttackEnd;
                GetComponent<Animator>().SetLayerWeight(0, 1.0f);
            }
        }
        GoToNextState();
    }

    protected IEnumerator AttackEndState()
    {
        GetComponent<Animator>().Play("Nothing");
        yield return new WaitForSeconds(cooldownAttack);
        if (state == State.AttackEnd)
        {
            state = State.Attack;
        }
        GoToNextState();
    }



    protected IEnumerator StunState()
    {
        while (state == State.Stun)
        {
            GetComponent<Animator>().Play("IsHit2");
            //GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
            if (state == State.Stun)
                state = State.Idle;
        }
        GoToNextState();
    }

}
