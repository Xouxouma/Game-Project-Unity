using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookIndice : MonoBehaviour
{

    public Image indice;

    private PauseMenuBehaviour pauseMenuBehaviour;
    // Start is called before the first frame update

    void Start()
    {
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
        indice.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pauseMenuBehaviour.hasClue() )
        {
            indice.enabled = !indice.enabled;
        }

    }
}