using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnVictory : MonoBehaviour
{
    public GameObject fence2;
    public GameObject fence3;
    public GameObject fence4;

    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;
    public GameObject tree5;
    public GameObject tree6;
    public GameObject thunder;

    public GameObject treeToDelete;

    private float init1;
    private float init2;
    private float init3;
    private float init4;
    private float init5;
    private float init6;
    // Start is called before the first frame update
    void Start()
    {
        init1 = tree1.transform.rotation.x;
        init2 = tree2.transform.rotation.x;
        init3 = tree3.transform.rotation.x;
        init4 = tree4.transform.rotation.x;
        init5 = tree5.transform.rotation.x;
        init6 = tree6.transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (tree1.transform.rotation.x != init1 && tree2.transform.rotation.x != init2 && tree3.transform.rotation.x != init3 && tree4.transform.rotation.x != init4 && tree5.transform.rotation.x != init5 && tree6.transform.rotation.x != init6)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Victory");
            fence2.GetComponent<Animator>().SetTrigger("Victory");
            fence3.GetComponent<Animator>().SetTrigger("Victory");
            fence4.GetComponent<Animator>().SetTrigger("Victory");
            thunder.SetActive(false);
            treeToDelete.SetActive(false);
        }
    }
}
