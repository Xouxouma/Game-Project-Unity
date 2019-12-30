using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnimator : MonoBehaviour
{
    public enum State { Idle, Chase, Attack };
    public State state;

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    // Start is called before the first frame update
    void Start()
    {
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
        while (state == State.Attack)
        {
            GetComponent<Animator>().Play("Attack");
            yield return 0;
        }
        GoToNextState();
    }

}
