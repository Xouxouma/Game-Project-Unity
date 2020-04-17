using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera firstPerson;
    public Camera thirdPerson;

    // Start is called before the first frame update
    void Start()
    {
        firstPerson.enabled = true;
        firstPerson.GetComponentInChildren<AudioListener>().enabled = true;
        thirdPerson.enabled = false;
        thirdPerson.GetComponentInChildren<AudioListener>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Tab))
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            firstPerson.enabled = !firstPerson.enabled;
            firstPerson.GetComponentInChildren<AudioListener>().enabled = !firstPerson.GetComponentInChildren<AudioListener>().enabled; 
            thirdPerson.enabled = !thirdPerson.enabled;
            thirdPerson.GetComponentInChildren<AudioListener>().enabled = !thirdPerson.GetComponentInChildren<AudioListener>().enabled;

        }

    }
}
