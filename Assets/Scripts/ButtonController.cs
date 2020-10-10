using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    //static bool that checkif if any of the dice switch it on
    public static bool somethingIsSelected = false;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (somethingIsSelected)
        {
            //Debug.Log("ON");
        }
        else
        {
            //Debug.Log("OFF");
        }
    }
}
