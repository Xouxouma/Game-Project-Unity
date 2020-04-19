using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFishHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerContainer")
        {
            other.gameObject.GetComponentInChildren<PlayerHealthBehaviour>().TakeDamages(1, transform.position, false);
        }
    }
}
