using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            GameObject.Find("ResumeButton").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSavedGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            Debug.Log("Loading game : " + save);

            GameObject sceneHandler = GameObject.Find("SceneHandler");
            SceneHandlerBehaviour sceneHandlerBehaviour = sceneHandler.GetComponent<SceneHandlerBehaviour>();
            sceneHandlerBehaviour.LoadScene(save);
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
