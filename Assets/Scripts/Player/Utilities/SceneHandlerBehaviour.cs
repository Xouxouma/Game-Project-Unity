using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandlerBehaviour : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadScene(Save save)
    {
        StartCoroutine(LoadNewScene(save));
    }

    IEnumerator LoadNewScene(Save save)
    {
        Debug.Log("Loading scene : " + save.activeScene);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(save.activeScene);
        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
           yield return null;

        Debug.Log("SCENE FULLY CHARGED : " + save);
         
        asyncOperation.allowSceneActivation = true;
        /*Scene scene = SceneManager.GetSceneByBuildIndex(save.activeScene);
        GameObject[] gameObjects = scene.GetRootGameObjects();
        if (gameObjects)
        GameObject.Find("CharacterContainer").transform.position = new Vector3(save.posX, save.posY, save.posZ);
        GameObject.Find("character").GetComponent<PlayerHealthBehaviour>().setHealth(save.hp, 10);
        Debug.Log("HP fixed");*/
    }

}
