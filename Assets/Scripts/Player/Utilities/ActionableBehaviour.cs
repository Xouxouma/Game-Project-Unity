using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionableBehaviour : MonoBehaviour
{
    public enum Action { Teleport };
    public Action action;


    private bool recup = false;
    private bool pressed = false;
    private InterfaceActionable actionable;
    private Image interact;

    // Start is called before the first frame update
    void Start()
    {
        actionable = GetComponent<InterfaceActionable>();
        switch (action)
        {
            case Action.Teleport:
                interact = (Image)GameObject.FindGameObjectWithTag("TeleportImage").GetComponent<Image>();
                break;
            default:
                Debug.LogWarning("ActionableBehaviour invalid Action");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pressed = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            pressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!recup)
        {
            interact.enabled = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        interact.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {

        if (pressed && !recup)
        {
            pressed = false;
            recup = true;

            Debug.Log("Activate");
            actionable.Activate();

            //StartCoroutine(timer(3));
        }
    }

    IEnumerator timer(int temps)
    {
        yield return new WaitForSecondsRealtime(temps);
    }
}
