﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    public AttackAnimation attackAnimation;
    public bool protectionOmw = false;
    public bool releaseProtectionOmw = false;
    protected bool fightEquip = true;
    private GameObject sword;
    private GameObject shield;
    private GameObject lamp;
    private PauseMenuBehaviour pauseMenuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.FindGameObjectWithTag("Sword");
        shield = GameObject.FindGameObjectWithTag("Shield");
        lamp = GameObject.FindGameObjectWithTag("Lamp");
        Debug.Log("Lamp = " + lamp);
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
        if (SceneManager.GetActiveScene().name == "Manoir")
            removeAll();
        else if (SceneManager.GetActiveScene().name != "Maze")
            equipSword(true);
        else removeSword(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (fightEquip)
                removeSword();
            else equipSword();
        }
        if (fightEquip)
        {
            // Sword
            if (Input.GetButtonDown("Fire1"))
            {
                if (attackAnimation.state == AttackAnimation.State.Protect)
                    protectionOmw = true;
                attackAnimation.state = AttackAnimation.State.Attack;
            }
            // Shield
            else if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("protection omw");
                protectionOmw = true;
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                Debug.Log("release PROTECTION OMW");
                releaseProtectionOmw = true;
            }

            if (protectionOmw && attackAnimation.state != AttackAnimation.State.Attack)
            {
                protectionOmw = false;
                attackAnimation.state = AttackAnimation.State.Protect;
            }
            else
            {
                if (protectionOmw)
                    Debug.Log("protectionOmw fail : " + attackAnimation.state);
            }
            if (releaseProtectionOmw && attackAnimation.state == AttackAnimation.State.Protect)
            {
                releaseProtectionOmw = false;
                attackAnimation.state = AttackAnimation.State.Nothing;
            }
            else
            {
                if (releaseProtectionOmw)
                    Debug.Log("releaseProtectionOmw fail : " + attackAnimation.state);
            }
        }
    }

    public bool hasFightEquip()
    {
        return fightEquip;
    }

    public void equipSword(bool force = false)
    {
        Debug.Log("Equip sword");
        fightEquip = true;
        if (force || pauseMenuBehaviour.hasSword())
        {
            sword.SetActive(true);
            shield.SetActive(true);
        } else
            fightEquip = false;
        lamp.SetActive(false);
    }

    public void removeSword(bool force = false)
    {
        attackAnimation.state = AttackAnimation.State.Nothing;
        Debug.Log("Remove sword");
        fightEquip = false;
        sword.SetActive(false);
        shield.SetActive(false);
        if (force || pauseMenuBehaviour.hasLamp())
        {
            lamp.SetActive(true);
        }
    }

    public void removeAll()
    {
        sword.SetActive(false);
        shield.SetActive(false);
        lamp.SetActive(false);
    }

}
