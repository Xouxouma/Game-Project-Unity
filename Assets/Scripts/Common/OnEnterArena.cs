using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterArena : MonoBehaviour
{
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        tree.GetComponent<Animator>().SetTrigger("OnEnter");
    }
}
