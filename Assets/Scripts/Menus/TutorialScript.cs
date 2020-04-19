﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject text;
    public GameObject player;

    private PauseMenuBehaviour pauseMenuBehaviour;

    private bool hasMoved = false;
    private bool hasRun = false;
    private bool hasJumped = false;
    private bool hasDoubleJumped = false;
    private bool hasAttacked = false;
    private bool hasProtected = false;
    private bool hasEquipped = false;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasMoved == false && (player.GetComponent<PlayerAnimate>().state == PlayerAnimate.State.Walk))
        {
            hasMoved = true;
            text.GetComponent<UnityEngine.UI.Text>().text = "Appuyez sur la touche Shift pour accélérer";
        }

        if (hasMoved == true && hasRun == false && (player.GetComponent<PlayerAnimate>().state == PlayerAnimate.State.Run))
        {
            hasRun = true;
            text.GetComponent<UnityEngine.UI.Text>().text = "Appuyez sur la touche Espace pour sauter";
        }

        if (hasMoved == true && hasRun == true && hasJumped == false && (player.GetComponent<PlayerAnimate>().state == PlayerAnimate.State.Jump))
        {
            hasJumped = true;
            text.GetComponent<UnityEngine.UI.Text>().text = "Appuyez deux fois sur Espace pour faire un double saut";
        }

        if (hasMoved == true && hasRun == true && hasJumped == true && hasDoubleJumped == false && (player.GetComponent<PlayerAnimate>().state == PlayerAnimate.State.DoubleJump))
        {
            hasDoubleJumped = true;
            text.GetComponent<UnityEngine.UI.Text>().text = "Faites un clic gauche de la souris pour attaquer";
        }

        if (hasMoved == true && hasRun == true && hasJumped == true && hasDoubleJumped == true && hasAttacked == false && (player.GetComponent<AttackAnimation>().state == AttackAnimation.State.Attack))
        {
            hasAttacked = true;
            text.GetComponent<UnityEngine.UI.Text>().text = "Maintenez le bouton droit pour vous protégez derrière le bouclier";
        }

        if (hasMoved == true && hasRun == true && hasJumped == true && hasDoubleJumped == true && hasAttacked == true && hasProtected == false && (player.GetComponent<AttackAnimation>().state == AttackAnimation.State.Protect))
        {
            hasProtected = true;
            text.GetComponent<UnityEngine.UI.Text>().text = "Appuyez sur 'Tab' pour changer l'arme.";
        }

        if (hasMoved == true && hasRun == true && hasJumped == true && hasDoubleJumped == true && hasAttacked == true && hasProtected == true && !hasEquipped && hasProtected && Input.GetKeyDown(KeyCode.Tab))
        {
            hasEquipped = true;
            text.SetActive(false);
            pauseMenuBehaviour.finishTuto();
        }
    }
}