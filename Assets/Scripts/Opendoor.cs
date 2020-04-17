using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opendoor : MonoBehaviour
{
    public Image interact;

    PauseMenuBehaviour pauseMenuBehaviour;
    
    // Start is called before the first frame update

    void Start()
    {
        interact.enabled = false;
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
    }

        private void OnTriggerEnter(Collider other)
    {
        interact.enabled = true ;
    }

    private void OnTriggerExit(Collider other)
    {
        interact.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && pauseMenuBehaviour.hasKey())
        {
            GetComponent<Animator>().Play("open");

        }
        else
        {
            Debug.Log("tu peux pas");
        }
        
    }

}
