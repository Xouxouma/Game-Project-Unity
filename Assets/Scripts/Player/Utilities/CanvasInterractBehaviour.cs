using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInterractBehaviour : MonoBehaviour
{
    public Image conversation;
    public Image parchemin;
    public Image obj;
    public Image save;
    public Image portal;

    public GameObject text;
    public GameObject textobj;

    public Image interact;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("conv = " + interact);
        parchemin.enabled = false;
        obj.enabled = false;
        conversation.enabled = false;
        text.SetActive(false);
        textobj.SetActive(false);
        interact.enabled = false;
        save.enabled = false;
        portal.enabled = false;
        Debug.Log("conv2 = " + interact);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
