using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableAnimator : MonoBehaviour
{
    public enum State { Nothing, IsHit, KO };
    public State state;

    private void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    void Start()
    {
        GoToNextState();
    }


    IEnumerator KOState()
    {
        while (state == State.KO)
        {
            GetComponent<Animator>().SetLayerWeight(4, 1.0f);
            GetComponent<Animator>().Play("KO");
            yield return new WaitForSeconds(3.633f);
        }
    }

    IEnumerator IsHitState()
    {
        while (state == State.IsHit)
        {
            GetComponent<Animator>().SetLayerWeight(3, 1.0f);
            GetComponent<Animator>().Play("IsHit");
            //GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length
            yield return new WaitForSeconds(0.267f);
            if (state == State.IsHit)
            {
                GetComponent<Animator>().SetLayerWeight(3, 0.0f);
                state = State.Nothing;
            }
        }
        GoToNextState();
    }

    IEnumerator NothingState()
    {
        while (state == State.Nothing)
        {
            yield return 0;
        }
        GoToNextState();
    }

}
