using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractLampe : MonoBehaviour
{
    public GameObject interact;
    public GameObject lumière;
    private bool pressed = false;
    public GameObject close, open;

    // Start is called before the first frame update

    void Start()
    {
        interact.SetActive(false);
        close.SetActive(true);
        open.SetActive(false);
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
        if (pressed)
        {
            pressed = false;
            lumière.SetActive(!lumière.active);
            close.SetActive(false);
            open.SetActive(true);

        }


    }
}
