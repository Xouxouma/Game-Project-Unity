using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{

    public enum State { Idle, Attack }
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
        Debug.Log("Start attack animator");
        state = State.Idle;
        GoToNextState();
        Debug.Log("Start attack animator 2");
    }

    IEnumerator AttackState()
    {
        Debug.Log("Char Slash : Enter");
        while (state == State.Attack)
        {
            Debug.Log("Char Jump in");
            GetComponent<Animator>().Play("Slash");
            state = State.Idle;
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
        Debug.Log("Char Slash : Exit");
        GoToNextState();
    }

    IEnumerator IdleState()
    {
        while (state == State.Idle)
        {
            //GetComponent<Animator>().Play("Idle");
            yield return 0;
        }
        GoToNextState();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
