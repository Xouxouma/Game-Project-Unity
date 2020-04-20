using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacePlatforme : MonoBehaviour
{
    public GameObject plat1;
    public GameObject plat2;
    public GameObject plat3;
    public GameObject plat4;
    public GameObject plat5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Replace()
    {
        plat1.transform.localPosition = new Vector3(2.358f, 0.54f, 0.411f);
        plat2.transform.localPosition = new Vector3(1.611f, 0.541f, 1.725f);
        plat3.transform.localPosition = new Vector3(-0.966f, 1.619f, 2.199f);
        plat4.transform.localPosition = new Vector3(-2.078f, 1.931f, 1.224f);
        plat5.transform.localPosition = new Vector3(-2.32f, 2.353f, -0.11f);

        plat1.GetComponent<DropPlatform>().drop = false;
        plat2.GetComponent<DropPlatform>().drop = false;
        plat3.GetComponent<DropPlatform>().drop = false;
        plat4.GetComponent<DropPlatform>().drop = false;
        plat5.GetComponent<DropPlatform>().drop = false;
    }
}