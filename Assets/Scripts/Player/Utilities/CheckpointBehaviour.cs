using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointBehaviour : MonoBehaviour
{
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
            pauseMenu.GetComponent<PauseMenuBehaviour>().SaveGame();
        } else
        {
            Debug.Log("no trigger save : " + other.tag + " name: " + other.name);
        }
    }


}
