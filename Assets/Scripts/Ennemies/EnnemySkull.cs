using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySkull : MonoBehaviour
{
    public float cooldown = 0.0f;
    private int damages = 2;
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
        if (other.tag == "Player" && cooldown <= 0.0f)
        {
            Debug.Log("Ennemy trigger player, aka: " + other.transform.name + " :  " + GetComponent<Collider>().transform.name);
            if (other.gameObject.GetComponentInChildren<PlayerHealthBehaviour>().TakeDamages(damages, transform.position))
                cooldown = 1.0f;
        }
        else if (other.name == "Shield")
        {
            Debug.Log("ennemy hits shield");
        }
    }
}
