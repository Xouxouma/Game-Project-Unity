

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
        animator = GetComponentInChildren<BossAnimate>();
        damageableAnimator = GetComponentInChildren<DamageableAnimator>();
        isRange = true;
        melee = false;
    }

}
