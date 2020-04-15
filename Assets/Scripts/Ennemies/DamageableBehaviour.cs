using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableBehaviour : MonoBehaviour
{
    public int maxHp = 20;
    public int hp;
    public bool hasContainerParent = true;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamages(int damages)
    {
        if (isActiveAndEnabled)
        {
            hp -= damages;
            if (this.hp <= 0)
            {
                if (hasContainerParent)
                    Destroy(transform.parent.gameObject);
                Debug.Log("Damageable killed : " + name);
                Destroy(gameObject);
            }
            Debug.Log("" + name + " takes " + damages + "damages. Hp : " + hp + " / " + maxHp);
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }
}
