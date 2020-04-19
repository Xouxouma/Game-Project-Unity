using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWatcher : MonoBehaviour
{
    public GameObject tree;
    private Animator treeDown;

    // Start is called before the first frame update
    void Start()
    {
        treeDown = tree.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (treeDown.GetCurrentAnimatorStateInfo(0).IsName("TreeFall"))
        {
            gameObject.SetActive(false);
        }
    }
}
