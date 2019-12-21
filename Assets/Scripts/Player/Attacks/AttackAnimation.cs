using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    public GameObject sword;
    public enum State { Nothing, Attack, Protect }
    public State state;
    private SwordBehaviour swordBehaviour;

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    // Start is called before the first frame update
    void Start()
    {
        swordBehaviour = sword.GetComponent<SwordBehaviour>();
        state = State.Nothing;
        GoToNextState();
    }

    IEnumerator AttackState()
    {
        Debug.Log("Torso Slash : Enter");
        GetComponent<Animator>().SetTrigger("Fire1Trigger");
        swordBehaviour.Activate();
        while (state == State.Attack)
        {
            GetComponent<Animator>().Play("Slash");
            yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime);
            state = State.Nothing;
        }
        swordBehaviour.Desactivate();
        Debug.Log("Torso Slash : Exit");
        GoToNextState();
    }

    IEnumerator ProtectState()
    {
        Debug.Log("Torso Protect : Enter");
        while (state == State.Protect)
        {
            GetComponent<Animator>().Play("ShieldProtection");
            yield return 0;
        }
        Debug.Log("Torso Protect : Exit");
        GoToNextState();
    }

    IEnumerator NothingState()
    {
        Debug.Log("Torso Nothing : Enter");
        while (state == State.Nothing)
        {
            //GetComponent<Animator>().Play("SwordNothing");
            yield return 0;
        }
        Debug.Log("Torso Nothing : Exit");
        GoToNextState();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
