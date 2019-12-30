using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int maxHp = 30;
    private int hp;
    private AttackAnimation animator;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        animator = GetComponent<AttackAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public bool TakeDamages(int dmg, Vector3 weaponPos)
    {
        if (animator.state == AttackAnimation.State.Protect)
        {

            Vector3 directionToTarget = transform.position - weaponPos;
            float angle = Vector3.Angle(transform.forward, directionToTarget);

            Debug.Log("Player in Protect state ; angle = " + angle);

            if (Mathf.Abs(angle) < 90)
            {
                Debug.Log("Hit blocked by shield");
                return false;
            }
            else
            {
                Debug.Log("Hit by behind");
            }
        }
        else Debug.Log("Player in state : " + animator.state);

        Debug.Log("Player suffers " + dmg + " dmg. Life : " + (hp - dmg));
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }

        return true;
    }

    void Die()
    {
        Debug.Log("Player is dead!");
    }
}
