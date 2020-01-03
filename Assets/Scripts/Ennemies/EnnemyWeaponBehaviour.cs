using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeaponBehaviour : MonoBehaviour
{
    public GameObject ennemi;
    private int damages = 2;
    private EnnemyAnimator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = ennemi.GetComponent<EnnemyAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ennemy trigger: " + GetComponent<Collider>().transform.name);
        if (animator.state == EnnemyAnimator.State.Attack && other.tag == "Player")
        {
            Debug.Log("Ennemy trigger player, aka: "+ other.transform.name +" :  " + GetComponent<Collider>().transform.name);
            other.gameObject.GetComponent<PlayerHealthBehaviour>().TakeDamages(damages, transform.position);
        } else if (animator.state == EnnemyAnimator.State.Attack && other.name == "Shield")
        {
            Debug.Log("ennemy hits shield");
        }
    }
}
