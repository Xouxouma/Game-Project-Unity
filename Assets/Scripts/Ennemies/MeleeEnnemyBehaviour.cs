using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    public float range = 3.0f;
    public float chaseDistance = 15.0f;

    private void HeadForDestination()
    {
        Vector3 destination = target.transform.position;
        agent.SetDestination(destination);
        FonctionsUtiles.DebugRay(transform.position, destination, Color.yellow);
    }

    private void Attack()
    {
        Debug.Log("Attack from " + transform.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("CharacterContainer");
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance < chaseDistance)
        {
            Debug.Log("chase");
            if (targetDistance > range)
            {
                HeadForDestination();
            }
            else
            {
                Attack();
            }
        }
        else
        {
            Debug.Log("Stop chase");
            agent.SetDestination(transform.position);
        }
    }
}
