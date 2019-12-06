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
        Debug.Log("Char Run : Enter");
        //GetComponent<Animator>().speed = 4.0f;
        while (state == State.Run)
        {
            GetComponent<Animator>().Play("Run");
            yield return 0;
        }
        Debug.Log("Char Run : Exit");
        GoToNextState();
    }

    IEnumerator IdleState()
    {
        Debug.Log("Char Idle : Enter");
        while (state == State.Idle)
        {
            GetComponent<Animator>().Play("Idle");
            yield return 0;
        }
        Debug.Log("Char Idle : Exit");
        GoToNextState();
    }

    IEnumerator WalkState()
    {
        //GetComponent<Animator>().speed = 5.0f;
        Debug.Log("Char Walk : Enter");
        while (state == State.Walk)
        {
            GetComponent<Animator>().Play("Walk");
            yield return 0;
        }
        Debug.Log("Char Walk : Exit");
        GoToNextState();
    }
    IEnumerator JumpState()
    {
        Debug.Log("Char Jump : Enter");
        while (state == State.Jump)
        {
            Debug.Log("Char Jump in");
            GetComponent<Animator>().Play("Jump");
            yield return 0;
        }
        Debug.Log("Char Jump : Exit");
        GoToNextState();
    }

    IEnumerator DoubleJumpState()
    {
        Debug.Log("Char DoubleJump : Enter");
        while (state == State.DoubleJump)
        {
            GetComponent<Animator>().Play("DoubleJump");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
        Debug.Log("Char DoubleJump : Exit");
        GoToNextState();
    }
}
