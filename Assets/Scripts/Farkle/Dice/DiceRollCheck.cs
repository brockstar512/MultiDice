using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollCheck : MonoBehaviour
{
    //this script goes on each trigger game object
    bool onGround;
    public int sideValue;


    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Ground")//if the trigger hits the collider with tag ground
        {
            //Debug.Log("__on the ground clollider");
            onGround = true;

        }
    }

    void OnTriggerExit(Collider col)//not grounded anymore
    {
        if(col.tag == "Ground")
        {
            onGround = false;
        }
    }

    //if the trigger is with the number its the opposite number that will be on top

    public bool OnGround()//which side is on the ground. that side will have a value and be true
    {
        return onGround;
    }
}
