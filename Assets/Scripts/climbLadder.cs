using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbLadder : MonoBehaviour
{
    GameObject playerObj;
    bool climb = false;
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("CharacterContainer");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerObj )
        {
            Debug.Log("cliimb");
            climb = true;
            playerObj.GetComponent<PlayerMove>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == playerObj)
        {
            climb = false;
            playerObj.GetComponent<PlayerMove>().enabled = true;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (climb)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                playerObj.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerObj.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
        
    }
}
