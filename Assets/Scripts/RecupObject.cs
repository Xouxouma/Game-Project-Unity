using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecupObject : MonoBehaviour
{
    public enum Object { key, lamp, sword }
    public Object objects;
    GameObject parchemin;
    GameObject obj;
    GameObject text;
    GameObject textobj;

    public Sprite key;
    public Sprite lamp;

    private bool recup = false;
    private bool pressed = false;
    public GameObject interact;
    // Start is called before the first frame update

    private PauseMenuBehaviour pauseMenuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        //parchemin.enabled = false;
        //obj.enabled = false;
        //text.SetActive(false);
        //textobj.SetActive(false);
        //interact.enabled = false;
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
        CanvasInterractBehaviour canvasInteract = GameObject.Find("CanvasInteract").GetComponent<CanvasInterractBehaviour>();
        parchemin = canvasInteract.parchemin;
        obj = canvasInteract.obj;
        text = canvasInteract.text;
        textobj = canvasInteract.textobj;
        interact = canvasInteract.interact;
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
        if (!recup)
        {
            interact.SetActive(true);
        }

    }


    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (pressed && !recup)
        {
            pressed = false;
            recup = true;
            if (objects == Object.key)
            {
                obj.SetActive(key);
                parchemin.SetActive(true);
                obj.SetActive(true);
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "La clé du manoir";
                textobj.SetActive(true);
                interact.SetActive(false);
                // set key
                pauseMenuBehaviour.AddKey();
                StartCoroutine(timer(3));

            }
            if (objects == Object.lamp)
            {

                obj.GetComponent<Image>().sprite = lamp;
                parchemin.SetActive(true);
                obj.SetActive(true);
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "Une lampe";
                textobj.SetActive(true);
                interact.SetActive(false);
                // set lamp
                StartCoroutine(timer(2));
            }
        }

        IEnumerator timer(int temps)
        {
            yield return new WaitForSecondsRealtime(temps);
            parchemin.SetActive(false);
            obj.SetActive(false);
            text.SetActive(false);
            textobj.SetActive(false);


        }
    }
}
