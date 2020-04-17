using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if(collided.tag == "Enemy")
        {
            Debug.Log("Collision");
            EnemyBehavior comportement = collided.transform.gameObject.GetComponent<EnemyBehavior>();
        }
        else
        {
            Debug.Log("Pas collision");
        }
    }
}
