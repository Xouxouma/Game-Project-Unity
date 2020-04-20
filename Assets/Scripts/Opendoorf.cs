using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opendoorf : MonoBehaviour
{
    public GameObject interact;
    private bool pressed = false;
    PauseMenuBehaviour pauseMenuBehaviour;
    public GameObject porte1, porte2;

    // Start is called before the first frame update

    void Start()
    {
        CanvasInterractBehaviour canvasInteract = GameObject.Find("CanvasInteract").GetComponent<CanvasInterractBehaviour>();
        interact = canvasInteract.interact;
        interact.SetActive(false);
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
        interact.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (pressed && pauseMenuBehaviour.hasLamp() && pauseMenuBehaviour.hasSword() && pauseMenuBehaviour.hasMagic())
        {
            pressed = false;
            porte1.SetActive(false);
            porte2.SetActive(false);

        }

    }

}