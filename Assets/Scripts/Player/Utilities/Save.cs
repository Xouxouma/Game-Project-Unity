using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public bool newArea = false;
    public int activeScene;
    public int hp;
    public int maxHp;
    public float posX;
    public float posY;
    public float posZ;
    //public Vector3 rotation;
    public bool key = false;
    public bool hiddenHeart1 = false;
    public bool hiddenHeart2 = false;
    public bool hiddenHeart3 = false;
    public bool lamp = true; // useless for now
    public bool sword = true; // useless for now
    public bool clue = false;
    public bool tutoDone = true;
    public bool magic = false;

    public override string ToString()
    {
        return "activeScene : " + activeScene + ", hp : " + hp + ", maxHp : " + maxHp + ", x : " + posX + ", y : " + posY + ", z : " + posZ + ", key : " + key + ", clue : " + clue + ", lamp : " + lamp + ", sword : " + sword + ", hiddenHeart1 : " + hiddenHeart1 + ", hiddenHeart2 : " + hiddenHeart2 + ", hiddenHeart3 : " + hiddenHeart3 + ", newArea : " + newArea + ", tutoDone : " + tutoDone + ", magic : " + magic;
    }
}
