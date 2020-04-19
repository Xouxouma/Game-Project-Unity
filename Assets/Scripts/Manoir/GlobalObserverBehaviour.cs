using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObserverBehaviour : MonoBehaviour
{
    public bool vert, bleu, jaune;
    public void setVert(bool choix)
    {
        vert = choix;
    }

    public void setBleu(bool choix)
    {
        bleu = choix;
    }

    public void setJaune(bool choix)
    {
        jaune = choix;
    }

    public void resetColor()
    {
        setVert(false);
        setBleu(false);
        setJaune(false);
    }
}
