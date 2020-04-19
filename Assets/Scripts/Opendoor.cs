﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opendoor : MonoBehaviour
{
    public GameObject interact;
    private bool pressed = false;

    // Start is called before the first frame update

    void Start()
    {
        CanvasInterractBehaviour canvasInteract = GameObject.Find("CanvasInteract").GetComponent<CanvasInterractBehaviour>();
        interact = canvasInteract.interact;
        interact.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressed = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            pressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interact.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (pressed)
        {
            pressed = false;
            GetComponent<Animator>().Play("open");

        }


    }

}