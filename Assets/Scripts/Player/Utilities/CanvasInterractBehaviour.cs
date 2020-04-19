using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInterractBehaviour : MonoBehaviour
{
    public GameObject conversation;
    public GameObject parchemin;
    public GameObject obj;
    public GameObject portal;
    public GameObject save;
    public GameObject saveSuccess;

    public GameObject text;
    public GameObject textobj;

    public GameObject interact;
    public Image indice;

    // Start is called before the first frame update
    void Start()
    {
        parchemin.SetActive(false);
        obj.SetActive(false);
        conversation.SetActive(false);
        text.SetActive(false);
        textobj.SetActive(false);
        interact.SetActive(false);
        save.SetActive(false);
        portal.SetActive(false);
        saveSuccess.SetActive(false);
        Debug.Log("indice = " + indice);
        indice.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
