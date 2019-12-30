using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSummonerBehaviour: MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject spawn;
    public float forwardForce = 50;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CharacterContainer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Summon()
    {
        Debug.Log("Summon a projectile");
        GameObject projectile = Instantiate(projectilePrefab, spawn.transform.position, spawn.transform.rotation);
        projectile.transform.LookAt(target.transform.position);
        Destroy(projectile, 5.0f);
    }
}
