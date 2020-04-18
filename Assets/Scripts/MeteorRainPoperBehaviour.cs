using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorRainPoperBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        Debug.Log("Loading meteor rain");
        SceneManager.LoadScene("MeteorRain", LoadSceneMode.Additive);
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.Lerp(Color.black, Color.black, Mathf.PingPong(Time.time, 1));
        Debug.Log("Meteor rain loaded");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
