using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecupObject : MonoBehaviour
{
    public enum Object { key, lamp, sword, magic }
    public Object objects;
    public GameObject parchemin;
    public GameObject obj;
    public GameObject text;
    public GameObject textobj;

    public Sprite key;
    public Sprite lamp;

    private bool recup = false;
    public GameObject interact;

    private PauseMenuBehaviour pauseMenuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        parchemin.SetActive(false);
        obj.SetActive(false);
        text.SetActive(false);
        textobj.SetActive(false);
        interact.SetActive(false);
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
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


        if (Input.GetKeyDown(KeyCode.E) && !recup)
        {
            recup = true;
            if (objects == Object.key)
            {
                pauseMenuBehaviour.AddKey();
                obj.GetComponent<Image>().sprite = key;
                parchemin.SetActive(true);
                obj.SetActive(true);
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "La clé du manoir";
                textobj.SetActive(true);
                interact.SetActive(false);
                // set key

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
                pauseMenuBehaviour.AddLamp();
                StartCoroutine(timer(3));
            }
            if (objects == Object.sword)
            {

                obj.GetComponent<Image>().sprite = lamp;
                parchemin.SetActive(true);
                obj.SetActive(true);
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "Une épée";
                textobj.SetActive(true);
                interact.SetActive(false);
                // set lamp
                pauseMenuBehaviour.addSword();
                StartCoroutine(timer(3));
            }
            if (objects == Object.magic)
            {

                obj.GetComponent<Image>().sprite = lamp;
                parchemin.SetActive(true);
                obj.SetActive(true);
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "utilise 'a' pour aller au boss";
                textobj.SetActive(true);
                interact.SetActive(false);
                // set lamp
                pauseMenuBehaviour.addMagic();
                StartCoroutine(timer(3));
            }

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