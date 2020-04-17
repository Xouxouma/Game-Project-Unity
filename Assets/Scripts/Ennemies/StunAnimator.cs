using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunAnimator : MonoBehaviour
{
    public enum State { Nothing, IsHit, ToStun, Stunned, StunToNormal, KO };
    public State state;
    public float stunTime = 5.0f;
    public Coroutine currentCoroutine;

    protected void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        //Debug.Log("StunAnimator : GoToNextState method : " + methodName);
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        currentCoroutine = StartCoroutine((IEnumerator)info.Invoke(this, null));
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

    IEnumerator NothingState()
    {
        while (state == State.Nothing)
        {
            yield return 0;
        }
        GoToNextState();
    }

    IEnumerator IsHitState()
    {
        while (state == State.IsHit)
        {
            GetComponent<Animator>().Play("IsHit");
            //float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            float remainingTime = stunTime;
            yield return new WaitForSeconds(remainingTime);
            if (state == State.IsHit)
                state = State.StunToNormal;
        }
        GoToNextState();
    }


    IEnumerator ToStunState()
    {
        while (state == State.ToStun)
        {
            GetComponent<Animator>().Play("ToStun");
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            if (state == State.ToStun)
            {
                //Debug.Log("ToStunState -> Stunned");
                state = State.Stunned;
            }
        }
        GoToNextState();
    }

    IEnumerator StunnedState()
    {
        while (state == State.Stunned)
        {
            GetComponent<Animator>().Play("Stunned");
            float remainingTime = stunTime * GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            //yield return new WaitForSeconds(stunTime);
            if (state == State.Stunned)
            {
                //Debug.Log("Stunned -> StunToNormal");
                state = State.StunToNormal;
            }
        }
        GoToNextState();
    }

    IEnumerator StunToNormalState()
    {
        while (state == State.StunToNormal)
        {
            GetComponent<Animator>().Play("StunToNormal");
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            if (state == State.StunToNormal)
            {
                //Debug.Log("StunToNormal -> Nothing");
                state = State.Nothing;
            }
        }
        GoToNextState();
    }
}
