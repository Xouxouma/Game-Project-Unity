using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public int damages = 10;
    private ParticleSystem trails;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        trails = GetComponentInChildren<ParticleSystem>();
        Desactivate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (isActive && collider.gameObject.GetComponent<DamageableBehaviour>() != null)
        {
            Debug.Log("Sword trigger by damageable " + collider.transform.name);
            collider.gameObject.GetComponent<DamageableBehaviour>().TakeDamages(damages);
        }
    }

    public void Activate()
    {
        //Debug.Log("Activate sword");
        isActive = true;
        trails.Play();
    }

    public void Desactivate()
    {
        //Debug.Log("Desactivate sword");
        isActive = false;
        trails.Stop();
    }
}
