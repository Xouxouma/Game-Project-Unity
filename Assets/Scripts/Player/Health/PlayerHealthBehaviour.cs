using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    private int maxHp = 6; // 1 heart = 2 hp
    private int hp = 6;
    private AttackAnimation animator;
    private SufferingAnimate sufferingAnimate;
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Sprite semiHeart;
    private bool isDead = false;
    public Camera deathCam;

    // Start is called before the first frame update
    void Start()
    {
        deathCam.enabled = false;
        if (maxHp / 2 > hearts.Length)
        {
            throw new Exception("more Hp than max hearts possible");
        }
        animator = GetComponent<AttackAnimation>();
        sufferingAnimate = GetComponent<SufferingAnimate>();
        updateHearts();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool TakeDamages(int dmg, Vector3 weaponPos)
    {
        if (isDead)
        {
            Debug.Log("Already dead");
            return false;
        }

        if (animator.state == AttackAnimation.State.Protect)
        {

            Vector3 directionToTarget = weaponPos - transform.position;
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
        sufferingAnimate.state = SufferingAnimate.State.IsHit;
        hp -= dmg;
        updateHearts();
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }

        return true;
    }

    void Die()
    {
        isDead = true;
        Camera.main.enabled = false;
        deathCam.enabled = true;
        Time.timeScale = 0f;
        Debug.Log("Player is dead!");
        sufferingAnimate.state = SufferingAnimate.State.Die;
    }

    public void Heal(int amount)
    {
        if (hp + amount > maxHp)
        {
            hp = maxHp;
        } else
        {
            hp += amount;
        }
        updateHearts();
    }

    public void FullHeal()
    {
        hp = maxHp;
        updateHearts();
    }

    public void AddHeart()
    {
        maxHp += 2;
        hp += 2;
        Debug.Log("AddHeart : maxHp =  " + maxHp);
        updateHearts();
    }

    void updateHearts()
    {
        Debug.Log("update Hearts" + hp + " / " + maxHp);
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHp / 2)
            {
                hearts[i].enabled = true;
                if ((i + 1) * 2 <= hp)
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

            } else
            {
                hearts[i].enabled = false;
            }
        }
        //Debug.Log("maxHp / 2 = " + maxHp / 2);
        //Debug.Log("hearts length" + (hearts.Length));
    }

    public int getHp()
    {
        return hp;
    }
    public int getMaxHp()
    {
        return maxHp;
    }
    public void setHealth(int hp, int maxHp)
    {
        Debug.Log("SetHealth " + hp + " / " + maxHp);
        if (isDead && hp > 0)
            resurect();
        this.hp = hp;
        this.maxHp = maxHp;
        updateHearts();
    }

    public void resurect()
    {
        Camera.main.enabled = true;
        deathCam.enabled = false;
        isDead = false;
        sufferingAnimate.state = SufferingAnimate.State.Nothing;
        Time.timeScale = 1f;
    }
}
