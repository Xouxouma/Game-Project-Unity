using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public GameObject impactEffect;

    protected int damages = 1;
    protected float velocity = 0.0f;
    protected GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CharacterContainer");
    }

    public void Throw(float vel)
    {
        if (target == null)
            target = GameObject.Find("CharacterContainer");
        transform.LookAt(target.transform.position);
        //Debug.Log("Throw at vel " + vel);
        velocity = vel;
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward.normalized * velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (velocity != 0.0f)
        {
            Debug.Log("Projectile hits : " + other.transform.name + " | tag : " + other.transform.tag);
            if (other.tag == "Player")
            {
                if (other.gameObject.GetComponent<PlayerHealthBehaviour>().TakeDamages(damages, transform.position))
                    Explode();
                else
                {
                    Debug.Log("projectile change sens");
                    velocity = -velocity;
                }
            }
            /*else if (other.tag == "Shield")
            {
                Debug.Log("Projectile hits shield");
                velocity = -velocity;
            }*/
            else if (other.tag == "PlayerContainer")
            {
                if (other.gameObject.GetComponentInChildren<PlayerHealthBehaviour>().TakeDamages(damages, transform.position))
                    Explode();
                else
                {
                    velocity = -velocity;
                }
            }
            else if (other.tag == "Terrain")
            {
                Explode();
            }
            /*else if (other.tag == "Ennemy")
            {

            }*/
            else if (other.tag == "Boss")
            {
                other.gameObject.GetComponent<BossBehaviour>().FireballHit();
                Explode();
            }
            else if (other.tag == "Projectile")
            {
                Explode();
            }
        }
    }

    protected void Explode()
    {
        if (impactEffect != null)
            Instantiate(impactEffect, transform.position, Quaternion.LookRotation(transform.forward));
        Destroy(gameObject);
    }
}
