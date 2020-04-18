using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    GameObject playerObj;
    public GameObject cle;
    bool open = false;
    AudioSource sound;
    private int i = 0;
    private int iMax = 30;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("CharacterContainer");
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
                GetComponent<Animator>().Play("Open");
                sound.Play();

                GetComponent<OpenChest>().enabled = false;
                Destroy(cle, 2.3f);
            }
            if (i < iMax)
            {
                cle.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 1);
                i++;
            }
        }

    }
}
