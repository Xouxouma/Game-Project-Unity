using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueletteBehavior : MonoBehaviour
{
    public enum State { Idle, Run, Die };
    public State state;

    public float moveSpeed = 1.0f;
    public float rotateSpeed = 3.0f;

    public float followRange = 10.0f;
    public float idleRange = 10.0f;

    private Transform target;
    public float GetDistance()
    {
        return (transform.position - target.position).magnitude;
    }

    private void RotateTowardsTarget()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotateSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(target.position.x - transform.position.x, transform.position.y, target.position.z - transform.position.z)), rotateSpeed * Time.deltaTime);
    }

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    IEnumerator IdleState()
    {
        Debug.Log("Idle:Enter");
        while (state == State.Idle)
        {
            GetComponent<Animator>().Play("Idle");
            if (GetDistance() < followRange)
            {
                state = State.Run;
            }
            yield return 0;
        }
        Debug.Log("Idle:Exit");
        GoToNextState();
    }

    IEnumerator RunState()
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("Chase : Enter");
        while (state == State.Run)
        {
            GetComponent<Animator>().Play("Run");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), moveSpeed * Time.deltaTime);
            RotateTowardsTarget();
            if (GetDistance() > idleRange)
            {
                state = State.Idle;
            }
            yield return 0;
        }
        Debug.Log("Chase : Exit");
        GoToNextState();
    }

    IEnumerator DieState()
    {
        GetComponent<Animator>().Play("Die");
        yield return new WaitForSeconds(4);

        state = State.Run;
        GoToNextState();
    }

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("CharacterContainer").transform;
        GoToNextState();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
