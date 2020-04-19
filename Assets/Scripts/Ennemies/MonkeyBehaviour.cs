using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    protected GameObject target;
    public float range = 3.0f;
    public float chaseDistance = 15.0f;
    protected EnnemyAnimator animator;
    protected DamageableAnimator damageableAnimator;
    public bool melee = true;
    public bool isRange = false;
    public float rotateSpeed = 10.0f;

    protected void HeadForDestination()
    {
        if (animator.state != EnnemyAnimator.State.Chase)
            animator.state = EnnemyAnimator.State.Chase;
        Vector3 destination = target.transform.position;
        FonctionsUtiles.DebugRay(transform.position, destination, Color.yellow);
    }

    protected void RotateTowardsTarget()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotateSpeed * Time.deltaTime);
    }

    protected void Attack()
    {
        RotateTowardsTarget();
        if (animator.state != EnnemyAnimator.State.Attack && animator.state != EnnemyAnimator.State.AttackEnd)
        {
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
        target = GameObject.Find("CharacterContainer");
        animator = GetComponentInChildren<EnnemyAnimator>();
        damageableAnimator = GetComponentInChildren<DamageableAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.state != EnnemyAnimator.State.Transformation && animator.state != EnnemyAnimator.State.Stun && damageableAnimator.state != DamageableAnimator.State.KO)
        //if (true)
        {

            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (targetDistance < chaseDistance)
            {
                if (!isRange || animator.state != EnnemyAnimator.State.Attack)
                {
                    if (targetDistance <= range)
                    {
                        Attack();
                    }
                }
                else
                {
                    RotateTowardsTarget();
                }
            }
            else
            {
                Idle();
            }
        }
    }

    void Idle()
    {
        if (animator.state != EnnemyAnimator.State.Idle)
            animator.state = EnnemyAnimator.State.Idle;
    }
}
