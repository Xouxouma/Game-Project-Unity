using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLava : MonoBehaviour
{
    private int damages = 10;
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
        Debug.Log("Lava trigger: " + GetComponent<Collider>().transform.name);
        if (other.tag == "Player" || other.name == "CharacterContainer")
        {
            Debug.Log("Ennemy trigger player, aka: " + other.transform.name + " :  " + GetComponent<Collider>().transform.name);
            other.gameObject.GetComponentInChildren<PlayerHealthBehaviour>().TakeDamages(damages, transform.position, false);
        }
    }
}
