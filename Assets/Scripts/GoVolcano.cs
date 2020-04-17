using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoVolcano : MonoBehaviour
{
    GameObject player;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        camera = player.GetComponentInChildren<Camera> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("VolcanoScene");
        SceneManager.LoadScene("MeteorRain", LoadSceneMode.Additive);
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.Lerp(Color.black,Color.black,Mathf.PingPong(Time.time,1));
    }
}
