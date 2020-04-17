using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    GameObject playerObj;
    bool drop = false;
    private float speed = 0.35f;
    AudioSource sound;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        playerObj = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == playerObj)
        {
            Debug.Log("yes");
            drop = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerObj)
        {
            Debug.Log("test");
            drop = true;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (drop)
        {
            if (!played)
            {
                sound.Play();
                played = true;
            }
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            
        }

    }
}