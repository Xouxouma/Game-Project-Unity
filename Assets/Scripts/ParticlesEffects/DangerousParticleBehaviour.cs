using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousParticleBehaviour : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public int damages = 1;
    public float cooldown = 0.0f;

    void Start()
    {
        ParticleSystem.EmissionModule emission = part.emission;
        //emission.enabled = false;
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }

    void OnParticleCollision(GameObject other)
    {
            //Debug.Log("Projectile hits : " + other.transform.name + " | tag : " + other.transform.tag);
            //if (other.tag == "PlayerContainer" /*&& cooldown <= 0.0f*/)
            if (other.tag == "Player" && cooldown <= 0.0f)
            {
                Debug.Log("Particles attack player");
                other.gameObject.GetComponent<PlayerHealthBehaviour>().TakeDamages(damages, transform.position, false);
                cooldown = 1.0f;
            }
    }

    protected void Explode()
    {

    }

}
