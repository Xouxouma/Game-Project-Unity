using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    public enum State { Idle, Walk, CastFireBall, CastAoe, ToStun, Stunned, StunToNormal, KO};
    public State state;
    public float stunTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        GoToNextState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
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

    IEnumerator WalkState()
    {
        while (state == State.Walk)
        {
            GetComponent<Animator>().Play("Walk");
            yield return 0;
        }
        GoToNextState();
    }

    IEnumerator ToStunState()
    {
        while (state == State.ToStun)
        {
            GetComponent<Animator>().Play("ToStun");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            state = State.Stunned;
        }
        GoToNextState();
    }

    IEnumerator StunnedState()
    {
        while (state == State.Stunned)
        {
            GetComponent<Animator>().Play("Stunned");
            yield return new WaitForSeconds(stunTime);
            state = State.StunToNormal;
        }
        GoToNextState();
    }

    IEnumerator StunToNormalState()
    {
        while (state == State.ToStun)
        {
            GetComponent<Animator>().Play("StunToNormal");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            state = State.Idle;
        }
        GoToNextState();
    }
}
