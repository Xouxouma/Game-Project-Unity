using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public enum State { Idle, Walk, Run, Jump, DoubleJump };
    public State state;

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

    IEnumerator RunState()
    {
        while (state == State.Run)
        {
            GetComponent<Animator>().Play("Run");
            yield return 0;
        }
        GoToNextState();
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
    IEnumerator JumpState()
    {
        while (state == State.Jump)
        {
            GetComponent<Animator>().Play("Jump");
            yield return 0;
        }
        GoToNextState();
    }

    IEnumerator DoubleJumpState()
    {
        while (state == State.DoubleJump)
        {
            GetComponent<Animator>().Play("DoubleJump");
            //yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length * (1 - GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime));
        }
        GoToNextState();
    }

}
