﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackAnimation attackAnimation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1 triggered : sword slash");
            attackAnimation.state = AttackAnimation.State.Attack;
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fire2 triggered : shield up");
            attackAnimation.state = AttackAnimation.State.Protect;
        } else if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("Shield down");
            attackAnimation.state = AttackAnimation.State.Nothing;
        }
    }
}
