using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrailBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Activate Sword Trail");
            gameObject.SetActive(true);
        }
    }
}
