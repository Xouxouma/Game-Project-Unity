using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnimator : MonoBehaviour
{
    public enum State { Idle, Chase, Attack, AttackEnd };
    public State state;
    private ProjectileSummonerBehaviour projectileSummonerBehaviour;
    public float cooldownAttack = 1.8f;

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
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

    IEnumerator IdleState()
    {
        while (state == State.Idle)
        {
            GetComponent<Animator>().Play("Idle");
            yield return 0;
        }
        GoToNextState();
    }

    IEnumerator ChaseState()
    {
        while (state == State.Chase)
        {
            GetComponent<Animator>().Play("Chase");
            yield return 0;
        }
        GoToNextState();
    }

    IEnumerator AttackState()
    {
        Debug.Log("ATTACKK" + GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).ToString());

        if (projectileSummonerBehaviour != null)
        {
            Debug.Log("attackk");
            projectileSummonerBehaviour.Summon();
        }
        while (state == State.Attack)
        {
            GetComponent<Animator>().Play("Attack");
            //yield return 0;
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            state = State.AttackEnd;
        }
        GoToNextState();
    }

    IEnumerator AttackEndState()
    {
        Debug.Log("AttackEnd enter");
        GetComponent<Animator>().Play("AttackEnd");
        state = State.Attack;
        yield return new WaitForSeconds(cooldownAttack);
        GoToNextState();
    }

}
