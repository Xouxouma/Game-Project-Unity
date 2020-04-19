using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchThunder : MonoBehaviour
{
    public ParticleSystem thunder;
    public GameObject Tree1;
    private Animator ATree1;
    
    public GameObject Tree2;
    private Animator ATree2;

    public GameObject Tree3;
    private Animator ATree3;

    public GameObject Tree4;
    private Animator ATree4;

    public GameObject Tree5;
    private Animator ATree5;

    public GameObject Tree6;
    private Animator ATree6;

    public GameObject Player;
    private ParticleSystem thisParticle;

    public bool strike = false;
    // Start is called before the first frame update
    void Start()
    {
        ATree1 = Tree1.GetComponent<Animator>();
        ATree2 = Tree2.GetComponent<Animator>();
        ATree3 = Tree3.GetComponent<Animator>();
        ATree4 = Tree4.GetComponent<Animator>();
        ATree5 = Tree5.GetComponent<Animator>();
        ATree6 = Tree6.GetComponent<Animator>();
        thisParticle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thunder.isPlaying)
        {
            float dx1 = Mathf.Abs(thunder.transform.position.x - Tree1.transform.position.x);
            float dz1 = Mathf.Abs(thunder.transform.position.z - Tree1.transform.position.z);
            if (dx1 < 30 && dz1 < 30)
            {
                StartCoroutine(treeDown(ATree1));
            }
            float dx2 = Mathf.Abs(thunder.transform.position.x - Tree2.transform.position.x);
            float dz2 = Mathf.Abs(thunder.transform.position.z - Tree2.transform.position.z);
            if (dx2 < 30 && dz2 < 30)
            {
                StartCoroutine(treeDown(ATree2));
            }
            float dx3 = Mathf.Abs(thunder.transform.position.x - Tree3.transform.position.x);
            float dz3 = Mathf.Abs(thunder.transform.position.z - Tree3.transform.position.z);
            if (dx3 < 30 && dz3 < 30)
            {
                StartCoroutine(treeDown(ATree3));
            }
            float dx4 = Mathf.Abs(thunder.transform.position.x - Tree4.transform.position.x);
            float dz4 = Mathf.Abs(thunder.transform.position.z - Tree4.transform.position.z);
            if (dx4 < 30 && dz4 < 30)
            {
                StartCoroutine(treeDown(ATree4));
            }
            float dx5 = Mathf.Abs(thunder.transform.position.x - Tree5.transform.position.x);
            float dz5 = Mathf.Abs(thunder.transform.position.z - Tree5.transform.position.z);
            if (dx5 < 30 && dz5 < 30)
            {
                StartCoroutine(treeDown(ATree5));
            }
            float dx6 = Mathf.Abs(thunder.transform.position.x - Tree6.transform.position.x);
            float dz6 = Mathf.Abs(thunder.transform.position.z - Tree6.transform.position.z);
            if (dx6 < 30 && dz6 < 30)
            {
                StartCoroutine(treeDown(ATree6));
            }

            StartCoroutine(playerHit());
        } else
        {
            strike = false;
        }
    }

    private IEnumerator treeDown(Animator animator)
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetTrigger("ThunderHit");
    }

    private IEnumerator playerHit()
    {
        if (!strike)
        {
            strike = true;
            yield return new WaitForSeconds(1.25f);
            float dx7 = Mathf.Abs(thunder.transform.position.x - Player.transform.position.x);
            float dz7 = Mathf.Abs(thunder.transform.position.z - Player.transform.position.z);
            print("dx : " + dx7);
            print("dz : " + dz7);
            if (dx7 < 5 && dz7 < 5)
            {
                Debug.Log("THUNDER HITS PLAYER");
                Player.GetComponent<PlayerHealthBehaviour>().TakeDamages(1, transform.position, false);
            }
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
