using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    public string sceneName;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("CanvasPauseMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.name == "CharacterContainer")
        {
            Debug.Log("Saving game...");
            pauseMenu.GetComponent<PauseMenuBehaviour>().SaveGame(true);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("no trigger save : " + other.tag + " name: " + other.name);
        }
    }
}
