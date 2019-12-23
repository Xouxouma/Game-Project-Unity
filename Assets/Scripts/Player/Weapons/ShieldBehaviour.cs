using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public AttackAnimation anim;
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
       //Debug.Log("shield triggered");
       /* if (anim.state == AttackAnimation.State.Protect)
        {
            Vector3 dir = other.gameObject.;
            dir = -dir;
            other.gameObject.rigidbody.velocity = dir * reflectivePower;

        }*/
    }
}
