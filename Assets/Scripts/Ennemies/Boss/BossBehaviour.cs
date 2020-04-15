using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject barrier;
    public ParticleSystem aoeSpellParticles;
    public ParticleSystem shockwaveParticles;

    DamageableBehaviour damageableBehaviour;
    BossAnimate bossAnimator;
    int phase = 1;

    // Start is called before the first frame update
    void Start()
    {
        damageableBehaviour = GetComponent<DamageableBehaviour>();
        bossAnimator = GetComponent<BossAnimate>();
        //damageableBehaviour.enabled = false;

        barrier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1 && damageableBehaviour.GetHp() <= 0.5 * damageableBehaviour.GetMaxHp())
        {
            ActivatePhase2();
        }
    }

    public void FireballHit()
    {
        Debug.Log("Fireball Hits Boss");
        bossAnimator.state = BossAnimate.State.IsHit;
        if (phase == 2)
        {
            setVulnerable();
        }
    }

    public void ActivatePhase2()
    {
        phase = 2;
        Debug.Log("Activate Boss phase 2 ");
        bossAnimator.state = BossAnimate.State.Transformation;
        barrier.SetActive(true);
        damageableBehaviour.enabled = false;
    }

    public int getPhase()
    {
        return phase;
    }

    public void setInvulnerable()
    {
        barrier.SetActive(true);
        damageableBehaviour.enabled = false;
    }

    public void setVulnerable()
    {
        barrier.SetActive(false);
        damageableBehaviour.enabled = true;
    }

    public void castAoe()
    {
        aoeSpellParticles.Emit(2000);
        shockwaveParticles.Emit(2);
    }
}
