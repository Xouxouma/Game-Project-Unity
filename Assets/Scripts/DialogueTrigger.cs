using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool start = false;
    private bool pressedTalk = false;

    public Image talk;


    private void Start()
    {
        talk.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressedTalk = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            pressedTalk = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        talk.enabled = true;
        FindObjectOfType<DialogueManager>().EndDialogue();

    }


    private void OnTriggerExit(Collider other)
    {
        talk.enabled = false;
        start = false;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (pressedTalk)
        {
            pressedTalk = false;
            if (start)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
            else
            {
                start = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }


    }
}
