using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    GameObject playerObj;
    public GameObject cle;
    bool open = false;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        sound = cle.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObj)
        {
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObj)
        {
            open = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (open)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("OK");
                GetComponent<Animator>().Play("Open");
                sound.Play();
                for (int i = 0; i < 30; i++)
                {
                    cle.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 1);
                }
                GetComponent<OpenChest>().enabled = false;
                //Destroy(cle);
            }
        }

    }
}
