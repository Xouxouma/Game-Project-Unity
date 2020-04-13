using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackAnimator : MonoBehaviour
{
    public enum State { Nothing, CastFireball, CastAoe, Cooldown };
    public State state;
    public float stunTime = 5.0f;
    protected ProjectileSummonerBehaviour projectileSummonerBehaviour;
    public float cooldown = 1.0f;

    protected void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    // Start is called before the first frame update
    void Start()
    {
        projectileSummonerBehaviour = gameObject.GetComponent<ProjectileSummonerBehaviour>();
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

    protected IEnumerator CastFireball()
    {
        while (state == State.CastFireball)
        {
            Debug.Log("Cast fireball !");
            GetComponent<Animator>().Play("CastFireball");
            //yield return 0;
            GetComponent<Animator>().SetLayerWeight(1, 1.0f);
            float remainingTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).length * GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime;
            yield return new WaitForSeconds(remainingTime);
            if (state == State.CastFireball)
            {
                GetComponent<Animator>().SetLayerWeight(1, 0.0f);
                projectileSummonerBehaviour.Summon();
                state = State.Cooldown;
            }
        }
        GoToNextState();
    }

    protected IEnumerator CooldownState()
    {
        while (state == State.CastFireball)
        {
            Debug.Log("Boss cooldown");
            yield return new WaitForSeconds(cooldown);
            state = State.Nothing;
        }
        GoToNextState();
    }

}
