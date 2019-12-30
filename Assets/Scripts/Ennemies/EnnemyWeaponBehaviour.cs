using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeaponBehaviour : MonoBehaviour
{
    public GameObject ennemi;
    public int damages = 10;
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
        if (animator.state == EnnemyAnimator.State.Attack && other.tag == "Player")
        {
            Debug.Log("Ennemy trigger " + GetComponent<Collider>().transform.name);
            other.gameObject.GetComponent<PlayerHealthBehaviour>().TakeDamages(damages, transform.position);
        } else if (animator.state == EnnemyAnimator.State.Attack && other.name == "Shield")
        {
            Debug.Log("ennemy hits shield");
        }
    }
}
