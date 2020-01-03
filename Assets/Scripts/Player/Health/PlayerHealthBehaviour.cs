using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int maxHp = 10; // 1 heart = 2 hp
    private int hp;
    private AttackAnimation animator;

    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Sprite semiHeart;

    // Start is called before the first frame update
    void Start()
    {
        if (maxHp / 2 > hearts.Length)
        {
            throw new Exception("more Hp than max hearts possible");
        }
        hp = maxHp;
        animator = GetComponent<AttackAnimation>();
        updateHearts();
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
            } else
            {
                Debug.Log("Hit by behind");
            }
        }
        else Debug.Log("Player in state : " + animator.state);

        Debug.Log("Player suffers " + dmg + " dmg. Life : " + (hp - dmg));
        hp -= dmg;
        updateHearts();
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

    void updateHearts()
    {
        for (int i=0; i < hearts.Length; i++)
        {
            if (i < maxHp / 2)
            {
                if ((i+1) * 2 <= hp)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    if (i == hp / 2 && hp % 2 == 1)
                    {
                        hearts[i].sprite = semiHeart;
                    }
                    else
                    {
                        hearts[i].sprite = emptyHeart;
                    }
                }
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
