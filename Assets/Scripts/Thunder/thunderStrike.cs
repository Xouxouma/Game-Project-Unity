using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderStrike : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem thunder;
    void Start()
    {
        thunder.Stop();
        StartCoroutine(Wait(4.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!thunder.isPlaying)
        {
            StartCoroutine(Wait(2.0f));
            StartCoroutine(playAnimation());
        }
    }

    IEnumerator playAnimation()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-5,5), 60 /*+ gameObject.transform.position.y*/, Random.Range(-5, 5));
        thunder.transform.position = gameObject.transform.position + randomPosition;
        thunder.Play();
        thunder.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.0f);
        thunder.Stop();
        //thunder.GetComponentInChildren<OnTouchThunder>().strike = false;
        thunder.GetComponent<AudioSource>().Stop();
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

}


