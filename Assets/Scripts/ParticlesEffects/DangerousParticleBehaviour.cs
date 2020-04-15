using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousParticleBehaviour : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public int damages = 1;

    void Start()
    {
        ParticleSystem.EmissionModule emission = part.emission;
        //emission.enabled = false;
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
            //Debug.Log("Projectile hits : " + other.transform.name + " | tag : " + other.transform.tag);
            if (other.tag == "Player")
            {
                Debug.Log("Particles attack player");
                if (other.gameObject.GetComponent<PlayerHealthBehaviour>().TakeDamages(damages, transform.position, false))
                    Explode();
                else
                {
                    Debug.Log("Player counters particle with shield");
                }
            }
    }

    protected void Explode()
    {

    }

}
