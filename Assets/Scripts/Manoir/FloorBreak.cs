using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{

    public GameObject floor;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //animation cassé 
        floor.SetActive(false);

    }
}
