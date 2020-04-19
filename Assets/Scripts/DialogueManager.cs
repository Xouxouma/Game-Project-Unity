using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Image fondConv;
    public Text textConv;
    public Animator animator;
    void Start()
    {
        sentences = new Queue<string>();
        fondConv.enabled = false;
        textConv.enabled = false;

    }

    public void StartDialogue(Dialogue dialogue)
    {
        fondConv.enabled = true;
        textConv.enabled = true;
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (0 == sentences.Count)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        textConv.text = sentence;
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
