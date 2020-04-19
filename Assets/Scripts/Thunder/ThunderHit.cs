using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderHit : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem thunder;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
