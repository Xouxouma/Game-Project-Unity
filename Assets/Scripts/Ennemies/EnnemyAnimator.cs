using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnimator : MonoBehaviour
{
    public enum State { Idle, Chase, Attack, AttackEnd, IsHit, Transformation };
    public State state;
    protected ProjectileSummonerBehaviour projectileSummonerBehaviour;
    public float cooldownAttack = 1.0f;
    protected Coroutine currentCoroutine;
    protected Coroutine previousCoroutine;

    protected void GoToNextState()
    {
        Debug.Log("Gotonextstate : " + state);
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        previousCoroutine = currentCoroutine;
        currentCoroutine = StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    // Start is called before the first frame update
    void Start()
    {
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
        if (projectileSummonerBehaviour != null)
        {
            projectileSummonerBehaviour.Summon();
        }
        while (state == State.Attack)
        {
            GetComponent<Animator>().Play("Attack");
            //yield return 0;
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            if (state == State.Attack)
                state = State.AttackEnd;
        }
        GoToNextState();
    }

    protected IEnumerator AttackEndState()
    {
        //GetComponent<Animator>().Play("AttackEnd");
        yield return new WaitForSeconds(cooldownAttack);
        if (state == State.AttackEnd)
        {
            state = State.Attack;
        }
        GoToNextState();
    }

    protected IEnumerator IsHitState()
    {
        while (state == State.IsHit)
        {
            GetComponent<Animator>().Play("IsHit");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            if (state == State.IsHit)
                state = State.Idle;
        }
        GoToNextState();
    }
}
