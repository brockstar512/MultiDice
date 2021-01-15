using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//here is the class
public class DiceLocationConfig//1
{
    //Dictionary<string, Vector3> diceLocation = new Dictionary<string, Vector3>();
    public Vector3[] diePosition;

    //this is a constructor

    //public DiceLocationConfig()
    //public DiceLocationConfig(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5, Vector3 d6)
    public DiceLocationConfig()
    {
        diePosition = new Vector3[6];
        //diePosition[0] = new Vector3(3.34f, 0f, 0f);
        //diePosition[1] = new Vector3(5.03f, 0f, 0f);
        //diePosition[2] = new Vector3(3.53f, 0, 1.61f);
        //diePosition[3] = new Vector3(1.89f, 0f, 1.61f);
        //diePosition[4] = new Vector3(0.34f, 0, -0.13f);
        //diePosition[5] = new Vector3(0.34f, 0, 1.35f);
    }

    //{//2
        //diePosition = new Vector3[6];
        //diePosition[0] = new Vector3(d1.x,d1.y,d1.z);
        //diePosition[1] = new Vector3(d2.x, d2.y, d2.z);
        //diePosition[2] = new Vector3(d3.x, d3.y, d3.z);
        //diePosition[3] = new Vector3(d4.x, d4.y, d4.z);
        //diePosition[4] = new Vector3(d5.x, d5.y, d5.z);
        //diePosition[5] = new Vector3(d6.x, d6.y, d6.z);

    //cannot make a static construct that takes an argument

    //}
         
}
