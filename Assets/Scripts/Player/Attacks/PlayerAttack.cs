using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AttackAnimation attackAnimation;
    public bool protectionOmw = false;
    public bool releaseProtectionOmw = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Sword
        if (Input.GetButtonDown("Fire1"))
        {
            if (attackAnimation.state == AttackAnimation.State.Protect)
                protectionOmw = true;
            attackAnimation.state = AttackAnimation.State.Attack;
        }
        // Shield
        else if (Input.GetButtonDown("Fire2") )
        {
            Debug.Log("protection omw");
            protectionOmw = true;
        } else if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("release PROTECTION OMW");
            releaseProtectionOmw = true;
        }

        if (protectionOmw && attackAnimation.state != AttackAnimation.State.Attack)
        {
            protectionOmw = false;
            attackAnimation.state = AttackAnimation.State.Protect;
        }
        else
        { if (protectionOmw)
            Debug.Log("protectionOmw fail : " + attackAnimation.state);
        }
        if (releaseProtectionOmw && attackAnimation.state == AttackAnimation.State.Protect)
        {
            releaseProtectionOmw = false;
            attackAnimation.state = AttackAnimation.State.Nothing;
        }
        else
        {
            if (releaseProtectionOmw)
                Debug.Log("releaseProtectionOmw fail : " + attackAnimation.state);
        }
    }

}
