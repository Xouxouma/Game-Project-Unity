using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    public GameObject sword;
    public GameObject trails;
    public enum State { Nothing, Attack, Protect, AttackEnd }
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
        //Debug.Log("Torso Slash : Enter");
        swordBehaviour.Activate();
        while (state == State.Attack)
        {
            trails.SetActive(true);
            GetComponent<Animator>().Play("Slash");
            //yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * (1- GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime));
            yield return new WaitForSeconds(0.433f);
            trails.SetActive(false);
            state = State.Nothing;
        }
        swordBehaviour.Desactivate();
        GoToNextState();
    }

    IEnumerator AttackEndState()
    {
        //Debug.Log("Torso SlashEnd : Enter");
        while (state == State.AttackEnd)
        {
            GetComponent<Animator>().Play("SlashEnd");
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            state = State.Nothing;
        }
        GoToNextState();
    }

    IEnumerator ProtectState()
    {
        //Debug.Log("Torso Protect : Enter");
        while (state == State.Protect)
        {
            GetComponent<Animator>().Play("ShieldProtection");
            yield return 0;
        }

        GoToNextState();
    }

    IEnumerator NothingState()
    {
        //Debug.Log("Torso Nothing : Enter");
        GetComponent<Animator>().SetLayerWeight(1, 0.0f);
        while (state == State.Nothing)
        {
            yield return 0;
        }
        GetComponent<Animator>().SetLayerWeight(1, 1.0f);
        GoToNextState();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
