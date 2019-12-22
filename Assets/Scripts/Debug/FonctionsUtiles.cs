using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonctionsUtiles : MonoBehaviour
{
    public static void DebugRay(Vector3 origin, Vector3 destination, Color c)
    {
        Vector3 direction = destination - origin;
        Debug.DrawRay(origin, direction, c);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
