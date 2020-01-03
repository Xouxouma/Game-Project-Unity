using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private int damages = 1;
    public float velocity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward.normalized * velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthBehaviour>().TakeDamages(damages, transform.position);
            Destroy(gameObject);
        }
        else if (other.name == "Shield")
        {
            Debug.Log("Projectile hits shield");
            velocity = -velocity;
        }
        else if (other.tag == "Terrain")
        {
            Destroy(gameObject);
        }

    }
}
