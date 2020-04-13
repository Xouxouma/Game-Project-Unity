using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SufferingAnimate : MonoBehaviour
{
    public enum State { Nothing, IsHit, Die, Dead };
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

    IEnumerator NothingState()
    {
        GetComponent<Animator>().SetLayerWeight(2, 0.0f);
        while (state == State.Nothing)
        {
            yield return 0;
        }
        GetComponent<Animator>().SetLayerWeight(2, 1.0f);
        GoToNextState();
    }

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    IEnumerator DieState()
    {
        GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        while (state == State.Die)
        {
            state = State.Dead;
            GetComponent<Animator>().Play("Die");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(2).length);
        }
        GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
        GoToNextState();
    }

    IEnumerator DeadState()
    {
        while (state == State.Dead)
        {
            GetComponent<Animator>().Play("Dead");
            yield return 0;
        }
        GoToNextState();
    }

    IEnumerator IsHitState()
    {
        while (state == State.IsHit)
        {
            GetComponent<Animator>().Play("IsHit");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(2).length);
            state = State.Nothing;
        }
        GoToNextState();
    }
}
