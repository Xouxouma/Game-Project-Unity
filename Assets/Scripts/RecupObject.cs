using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecupObject : MonoBehaviour
{
    public enum Object { key, lamp, sword }
    public Object objects;
    public Image parchemin;
    public Image obj;
    public GameObject text;
    public GameObject textobj;

    public Sprite key;
    public Sprite lamp;

    private bool recup = false;
    public Image interact;

    private PauseMenuBehaviour pauseMenuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        parchemin.enabled = false;
        obj.enabled = false;
        text.SetActive(false);
        textobj.SetActive(false);
        interact.enabled = false;
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!recup)
        {
            interact.enabled = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        interact.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !recup)
        {
            Debug.Log("Recup " + objects);
            recup = true;
            if (objects == Object.key)
            {
                obj.sprite = key;
                parchemin.enabled = true;
                obj.enabled = true;
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "La clé du manoir";
                textobj.SetActive(true);
                interact.enabled = false;
                // set key
                pauseMenuBehaviour.AddKey();
                StartCoroutine(timer(3));

            }
            if (objects == Object.lamp)
            {

                obj.sprite = lamp;
                parchemin.enabled = true;
                obj.enabled = true;
                text.SetActive(true);
                textobj.GetComponent<Text>().text = "Une lampe";
                textobj.SetActive(true);
                interact.enabled = false;
                // set lamp
                pauseMenuBehaviour.AddLamp();
                StartCoroutine(timer(3));
            }
        }

        IEnumerator timer(int temps)
        {
            yield return new WaitForSecondsRealtime(temps);
            parchemin.enabled = false;
            obj.enabled = false;
            text.SetActive(false);
            textobj.SetActive(false);


        }
    }
}
