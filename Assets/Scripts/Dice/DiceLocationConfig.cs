using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//here is the class
public class DiceLocationConfig//1
{
    public Vector3[] diePosition;

    //this is a constructor
    //public DiceLocationConfig(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5, Vector3 d6)
    public DiceLocationConfig()
    {
        diePosition = new Vector3[6];
    }

}

//diePosition[0] = new Vector3(3.34f, 0f, 0f);
//diePosition[1] = new Vector3(5.03f, 0f, 0f);
//diePosition[2] = new Vector3(3.53f, 0, 1.61f);
//diePosition[3] = new Vector3(1.89f, 0f, 1.61f);
//diePosition[4] = new Vector3(0.34f, 0, -0.13f);
//diePosition[5] = new Vector3(0.34f, 0, 1.35f);

//cannot make a static construct that takes an argument
//what if the instance is static but the class is not and still has overloads...condtructor parameter arguments
