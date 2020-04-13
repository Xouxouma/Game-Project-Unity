using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossNavigator : EnnemyNavigator
{
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("CharacterContainer");
        //animator = GetComponentInChildren<EnnemyAnimator>();
        animator = GetComponentInChildren<BossAnimate>();
        isRange = true;
        melee = false;

        //Debug.Log("init state" + animator.state);
        //animator.state = BossAnimate.State.AttackEnd;
        //Debug.Log("boss animator.state" + animator.state);
        //animator.state = EnnemyAnimator.State.Attack;
        //Debug.Log("ennemy animator.state" + animator.state);
    }

}
