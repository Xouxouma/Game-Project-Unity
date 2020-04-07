using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject player;
    Save save;

    // Start is called before the first frame update
    void Start()
    {
        save = new Save();
        player = GameObject.Find("character");
        LastCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LastCheckpoint()
    {
        Debug.Log("LAST CHECKPOINT");
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            int hp = player.GetComponent<PlayerHealthBehaviour>().getHp();
            int maxHp = player.GetComponent<PlayerHealthBehaviour>().getMaxHp();
            player.GetComponent<PlayerHealthBehaviour>().setHealth(save.hp, save.maxHp);
            hp =player.GetComponent<PlayerHealthBehaviour>().getHp();
            maxHp = player.GetComponent<PlayerHealthBehaviour>().getMaxHp();
            Debug.Log("player sethealth AFTER : " + hp + " / " + maxHp);
            if (!save.newArea)
            {
                GameObject characterContainer = GameObject.Find("CharacterContainer");
                Debug.Log("Charc pos AV  = " + characterContainer.transform.position);
                characterContainer.transform.position = new Vector3(save.posX, save.posY + 2, save.posZ);
                Debug.Log("Charc pos AP = " + characterContainer.transform.position);
                Debug.Log("Pos in save = (" + save.posX + ", "+ save.posY +", " + save.posY + ")");
                if (!save.hiddenHeart)
                    Destroy(GameObject.FindGameObjectWithTag("ExtraHeart"));
                if (!save.key)
                    Destroy(GameObject.FindGameObjectWithTag("Key"));
                this.save.hiddenHeart = save.hiddenHeart;
                this.save.key = save.key;
                Debug.Log("Game Loaded : " + save);
            }
        }
        else
        {
            Debug.Log("No game saved!");
        }
        Resume();
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu : under construction");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private Save FillSaveGameObject()
    {
        save.activeScene = SceneManager.GetActiveScene().buildIndex;
        save.hp = player.GetComponent<PlayerHealthBehaviour>().getHp();
        save.maxHp = player.GetComponent<PlayerHealthBehaviour>().getMaxHp();
        save.posX = player.transform.position.x;
        save.posY = player.transform.position.y;
        save.posZ = player.transform.position.z;
        //save.rotation = player.transform.rotation;
        return save;
    }

    public void SaveGame()
    {
        Save save = FillSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved : " + save);
    }

    public void RemoveHeartFromSave()
    {
        save.hiddenHeart = false;
    }
    public void RemoveKey()
    {
        save.key = false;
    }
}
