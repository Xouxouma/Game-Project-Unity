using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyNavigator : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    public float range = 3.0f;
    public float chaseDistance = 15.0f;
    private EnnemyAnimator animator;
    public bool melee = true;
    public bool isRange = false;
    public float rotateSpeed = 10.0f;

    private void HeadForDestination()
    {
        if (animator.state != EnnemyAnimator.State.Chase)
            animator.state = EnnemyAnimator.State.Chase;
        Vector3 destination = target.transform.position;
        agent.SetDestination(destination);
        FonctionsUtiles.DebugRay(transform.position, destination, Color.yellow);
    }

    private void RotateTowardsTarget()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotateSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        //RotateTowardsTarget();
        if (animator.state != EnnemyAnimator.State.Attack && animator.state != EnnemyAnimator.State.AttackEnd)
        {
            if (isRange)
            {
                agent.SetDestination(transform.position);
            }
            animator.state = EnnemyAnimator.State.Attack;
        }
        if (animator.state == EnnemyAnimator.State.AttackEnd)
        {
            if (isRange)
                RotateTowardsTarget();
            else
                HeadForDestination();
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("CharacterContainer");
        animator = GetComponentInChildren<EnnemyAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        if (targetDistance < chaseDistance)
        {
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
            Idle();
        }
    }

    void Idle()
    {
        if (animator.state != EnnemyAnimator.State.Idle)
            animator.state = EnnemyAnimator.State.Idle;
        agent.SetDestination(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (melee && animator.state == EnnemyAnimator.State.Attack)
        {
            agent.SetDestination(transform.position);
        }
    }

}
