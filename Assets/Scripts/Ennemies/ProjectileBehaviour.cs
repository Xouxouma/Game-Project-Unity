using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour: MonoBehaviour
{
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Summon()
    {
        Debug.Log("Summon a projectile");
        GameObject projectile = Instantiate(projectilePrefab, transform);
    }
}
