using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAt : MonoBehaviour
{
    public enum Object { tableau, labIndice }
    public Object objects;
    public Image indice;
    public Image tableau;
    public GameObject text;
    private bool recup = false;
    private bool pressed = false;
    public Image look;
    PauseMenuBehaviour pauseMenuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        indice.enabled = false;
        tableau.enabled = false;
        look.enabled = false;
        if (text != null)
            text.SetActive(false);
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
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
        look.enabled = true;
    }


    private void OnTriggerExit(Collider other)
    {
        look.enabled = false;
        tableau.enabled = false;
        indice.enabled = false;
        if (text != null)
            text.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (pressed)
        {
            pressed = false;
            recup = true;
            if (objects == Object.labIndice)
            {
                pauseMenuBehaviour.addClue();
                Debug.Log("indice = " + indice);
                indice.enabled = !indice.enabled;
                text.SetActive(true);
                Destroy(gameObject);
            }
            if (objects == Object.tableau)
            {
                tableau.enabled = !tableau.enabled;
            }
        }
    }
}