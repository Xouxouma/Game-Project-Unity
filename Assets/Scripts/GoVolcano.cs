using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoVolcano : MonoBehaviour
{
    //public string sceneName;
    GameObject player;
    Camera camera;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("CanvasPauseMenu");
        player = GameObject.FindGameObjectWithTag("CharacterContainer");
        camera = player.GetComponentInChildren<Camera> ();
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
            //SceneManager.LoadScene(sceneName);
            SceneManager.LoadScene("VolcanoScene");
            SceneManager.LoadScene("MeteorRain", LoadSceneMode.Additive);
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.Lerp(Color.black,Color.black,Mathf.PingPong(Time.time,1));
        }
    }
}
