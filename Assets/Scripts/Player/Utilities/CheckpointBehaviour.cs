using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointBehaviour : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player  = GameObject.Find("character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.name == "CharacterContainer")
        {
            Debug.Log("TRIGGER SAVE");
            SaveGame();
        } else
        {
            Debug.Log("no trigger save : " + other.tag + " name: " + other.name);
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.activeScene = SceneManager.GetActiveScene().buildIndex;
        save.hp = player.GetComponent<PlayerHealthBehaviour>().getHp();
        save.maxHp = player.GetComponent<PlayerHealthBehaviour>().getMaxHp();
        save.posX = player.transform.position.x;
        save.posY = player.transform.position.y;
        save.posZ = player.transform.position.z;
        //save.rotation = player.transform.rotation;
        return save;
    }

    void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }
}
