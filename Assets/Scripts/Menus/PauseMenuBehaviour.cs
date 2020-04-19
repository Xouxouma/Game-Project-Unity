using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuBehaviour : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject player;
    Save save;
    public bool isDeathMenu = false;
    private GameObject saveIcon;
    private GameObject saveSuccessIcon;

    // Start is called before the first frame update
    void Start()
    {
        save = new Save();
        player = GameObject.Find("character");
        LastCheckpoint();
        Cursor.lockState = CursorLockMode.Locked;
        saveIcon = GameObject.FindGameObjectWithTag("SaveImage");
        saveSuccessIcon = GameObject.FindGameObjectWithTag("SaveSuccessImage");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeathMenu && Input.GetKeyDown(KeyCode.Escape))
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

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
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
            if (!save.newArea)
            {
                GameObject characterContainer = GameObject.Find("CharacterContainer");
                Vector3 newPos = new Vector3(save.posX, save.posY + 2, save.posZ);
                characterContainer.transform.position = newPos;
                CharacterController charController = characterContainer.GetComponent<CharacterController>();
                charController.enabled = false;
                charController.transform.position = newPos;
                charController.enabled = true;
            }
            if (save.hiddenHeart1)
                Destroy(GameObject.FindGameObjectWithTag("ExtraHeart1"));
            if (save.hiddenHeart2)
                Destroy(GameObject.FindGameObjectWithTag("ExtraHeart2"));
            if (save.hiddenHeart3)
                Destroy(GameObject.FindGameObjectWithTag("ExtraHeart3"));
            if (save.key)
                Destroy(GameObject.FindGameObjectWithTag("Key"));
            if (!save.lamp)
                Destroy(GameObject.FindGameObjectWithTag("Lamp"));
            if (!save.sword)
            {
                Destroy(GameObject.FindGameObjectWithTag("Sword"));
                Destroy(GameObject.FindGameObjectWithTag("Shield"));
            }
            this.save.hiddenHeart1 = save.hiddenHeart1;
            this.save.hiddenHeart2 = save.hiddenHeart2;
            this.save.hiddenHeart3 = save.hiddenHeart3;
            this.save.key = save.key;
            this.save.lamp = save.lamp;
            this.save.sword = save.sword;
            Debug.Log("Game Loaded : " + save);
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

    private Save FillSaveGameObject(bool newArea = false)
    {
        save.activeScene = SceneManager.GetActiveScene().buildIndex;
        save.hp = player.GetComponent<PlayerHealthBehaviour>().getHp();
        save.maxHp = player.GetComponent<PlayerHealthBehaviour>().getMaxHp();
        save.posX = player.transform.position.x;
        save.posY = player.transform.position.y;
        save.posZ = player.transform.position.z;
        //save.rotation = player.transform.rotation;
        save.newArea = newArea;
        return save;
    }

    public void SaveGame(bool newArea = false)
    {
        
        Save save = FillSaveGameObject(newArea);

        saveIcon.SetActive(true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved : " + save);
        saveIcon.SetActive(false);
        StartCoroutine(timer_logo(3, saveSuccessIcon));

    }

    IEnumerator timer_logo(int temps, GameObject icon)
    {
        Debug.Log("timer_logo " + icon);
        icon.SetActive(true);
        yield return new WaitForSecondsRealtime(temps);
        Debug.Log("End timer_logo" + icon);
        icon.SetActive(false);
    }

    public void AddHeartInSave(string tag)
    {
        switch (tag)
        {
            case "ExtraHeart1":
                save.hiddenHeart1 = true;
                break;
            case "ExtraHeart2":
                save.hiddenHeart2 = true;
                break;
            case "ExtraHeart3":
                save.hiddenHeart3 = true;
                break;
            default:
                Debug.Log("Add heart with wrong tag: won't save it");
                break;
        }
        SaveGame();
    }
    public void RemoveKey()
    {
        save.key = false;
    }
    public void AddKey()
    {
        save.key = true;
        SaveGame();
    }

    public void AddLamp()
    {
        save.lamp = true;
        SaveGame();
    }

    public bool hasKey()
    {
        return save.key;
    }
    public void addClue()
    {
        save.clue = true;
        SaveGame();
    }
    public bool hasClue()
    {
        return save.clue;
    }

    public bool hasLamp()
    {
        return save.lamp;
    }
    public void addSword()
    {
        save.sword = true;
        SaveGame();
    }
    public bool hasSword()
    {
        return save.sword;
    }

    public void finishTuto()
    {
        save.tutoDone = true;
        SaveGame();
    }
    public bool didTuto()
    {
        return save.tutoDone;
    }

}
