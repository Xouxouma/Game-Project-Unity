using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookEnigme : MonoBehaviour
{
    private bool pressed;
    public enum CouleurLivre { Vert, Bleu, Rouge, Violet, Jaune }
    public CouleurLivre couleurLivre;
    public GameObject globalObserver;
    public GameObject interact;
    public GameObject biblio1, biblio2, biblio3, biblio4;

    // Start is called before the first frame update
    void Start()
    {
        globalObserver.GetComponent<GlobalObserverBehaviour>().resetColor();
        pressed = false;
    }

    private void Update()
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
        interact.SetActive(true);


    }

    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (pressed)
        {
            pressed = false;
            if (couleurLivre == CouleurLivre.Violet)
            {
                globalObserver.GetComponent<GlobalObserverBehaviour>().resetColor();
            }

            if (globalObserver.GetComponent<GlobalObserverBehaviour>().bleu)
            {
                Debug.Log("passe jaune");
                if (globalObserver.GetComponent<GlobalObserverBehaviour>().jaune)
                {
                    Debug.Log("passe vert");
                    if (globalObserver.GetComponent<GlobalObserverBehaviour>().vert)
                    {
                        if (couleurLivre == CouleurLivre.Rouge)
                        {
                            biblio1.SetActive(false);
                            biblio2.SetActive(false);
                            biblio3.SetActive(false);
                            biblio4.SetActive(false);
                        }
                        else
                        {
                            globalObserver.GetComponent<GlobalObserverBehaviour>().resetColor();
                        }

                    }
                    else if (couleurLivre == CouleurLivre.Vert)
                    {
                        globalObserver.GetComponent<GlobalObserverBehaviour>().setVert(true);
                    }
                    else
                    {
                        globalObserver.GetComponent<GlobalObserverBehaviour>().resetColor();
                    }
                }
                else if (couleurLivre == CouleurLivre.Jaune)
                {
                    globalObserver.GetComponent<GlobalObserverBehaviour>().setJaune(true);
                }
                else
                {
                    globalObserver.GetComponent<GlobalObserverBehaviour>().resetColor();
                }
            }   
            else if (couleurLivre == CouleurLivre.Bleu)
            {
                globalObserver.GetComponent<GlobalObserverBehaviour>().setBleu(true);
            }
            else
            {
                globalObserver.GetComponent<GlobalObserverBehaviour>().resetColor();
            }
        }
    }
}
