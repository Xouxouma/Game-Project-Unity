using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour
{
    public enum State { Idle, Run};
    public State state;

    public Transform target;
    public float moveSpeed = 1.0f;
    public float rotateSpeed = 3.0f;
    public float followRange = 50.0f;
    public float idleRange = 10.0f;

    public float GetDistance()
    {
        return (transform.position - target.position).magnitude;
    }
    public void RotateTowardsTarget()
    {
       // transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.position - transform.position), rotateSpeed * Time.deltaTime);
        Vector3 nouvelleDestination = new Vector3(target.position.x - transform.position.x, transform.position.y, target.position.z - transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nouvelleDestination), rotateSpeed * Time.deltaTime);
    }

    void GoToNextState()
    {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info = GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }

    IEnumerator IdleState()
    {
        Debug.Log("Idle : Enter");
        while(state == State.Idle)
        {
            GetComponent<Animator>().Play("Idle");
            if(GetDistance() < followRange)
            {
                state = State.Run;
            }
            yield return 0;
        }
        Debug.Log("Idle : Exit");
        GoToNextState();
    }

    IEnumerator ChaseState()
    {
        Debug.Log("Chase : Enter");
        while (state == State.Run)
        {
            GetComponent<Animator>().Play("Chase");
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            Vector3 nouvellePosition = new Vector3(target.position.x, transform.position.y, target.position.z);
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
    // Start is called before the first frame update
    void Start()
    {
        GoToNextState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
