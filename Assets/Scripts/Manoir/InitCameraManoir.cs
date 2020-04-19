using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCameraManoir : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    private bool change = false;
    private bool unefois = true;
    private PauseMenuBehaviour pauseMenuBehaviour;

    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
        pauseMenuBehaviour.RemoveLamp();
        pauseMenuBehaviour.RemoveSword();
    }

    void Update()
    {
        if (change && unefois)
        {
            unefois = false;
            cam1.enabled = false;
            cam2.enabled = true;
            pauseMenuBehaviour.RemoveLamp();
            pauseMenuBehaviour.RemoveSword();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        change = true;

    }
}