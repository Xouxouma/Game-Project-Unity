using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    private bool change = false;
    private bool unefois =true;

    void Start()
    {
        cam1.enabled = false;
        cam2.enabled = false;
    }

    void Update()
    {
        if(change && unefois)
        {
            change = false;
            unefois = false;
            cam2.enabled = !cam2.enabled;
            cam1.enabled = !cam1.enabled;
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        unefois = true;
        change = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        change = true;

    }
}


