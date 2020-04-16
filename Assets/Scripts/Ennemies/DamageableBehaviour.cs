using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableBehaviour : MonoBehaviour
{
    public int maxHp = 20;
    public int hp;
    public bool hasContainerParent = true;
    DamageableAnimator damageableAnimator;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        damageableAnimator = GetComponent<DamageableAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamages(int damages)
    {
        if (isActiveAndEnabled && hp > 0)
        {
            hp -= damages;
            if (this.hp <= 0)
            {
                damageableAnimator.state = DamageableAnimator.State.KO;
                if (hasContainerParent)
                    Destroy(transform.parent.gameObject, 3.5f);
                Debug.Log("Damageable killed : " + name);
                Destroy(gameObject, 3.5f);
            }
            else
            {
                damageableAnimator.state = DamageableAnimator.State.IsHit;
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
