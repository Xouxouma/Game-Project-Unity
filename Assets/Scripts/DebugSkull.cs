using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSkull : MonoBehaviour
{
    Transform t;
    float fixedRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    void Update()
    {
        t.eulerAngles = new Vector3(fixedRotation, t.eulerAngles.y, fixedRotation);
    }
}
