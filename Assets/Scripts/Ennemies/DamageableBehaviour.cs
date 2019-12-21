using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableBehaviour : MonoBehaviour
{
    public int maxHp = 20;
    private int hp;
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
        Debug.Log("" + name + " takes " + damages + "damages");
        hp -= damages;
        if (this.hp == 0)
        {
            Debug.Log("Damageable killed : " + name);
            Destroy(gameObject);
        }
        Debug.Log("current_hp of " + name + " : " + hp);
    }
}
