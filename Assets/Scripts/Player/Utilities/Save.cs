using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int activeScene;
    public int hp;
    public int maxHp;
    public float posX;
    public float posY;
    public float posZ;
    //public Vector3 rotation;
    public int nbOfCrytstals;

    public override string ToString()
    {
        return "activeScene : " + activeScene + ", hp : " + hp + ", maxHp : " + maxHp + ", x : " + posX + ", y : " + posY + ", z : " + posZ + ", nbOfCrystals : " + nbOfCrytstals;
    }
}
