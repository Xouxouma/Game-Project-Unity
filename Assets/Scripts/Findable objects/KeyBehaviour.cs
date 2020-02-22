using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public float actionDistance = 1.0f;
    private GameObject target;
    private PauseMenuBehaviour pauseMenuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("character");
        pauseMenuBehaviour = GameObject.Find("CanvasPauseMenu").GetComponent<PauseMenuBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <= actionDistance)
        {
            Activate();
        }
    }

    private void Activate()
    {
        pauseMenuBehaviour.RemoveKey();
        Destroy(gameObject);
    }
}
