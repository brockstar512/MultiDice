using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public GameObject buttonAndDicePrefab;
    private GameObject totalDiceGroup;
    //public static DiceLocationConfig diceLocationConfig;//3 declare
    public DiceLocationConfig diceLocationConfig = new DiceLocationConfig();//3 declare


    //serialize position of the die
    //instantiate all of the die and get get there position
    //that way all of the dice will have the same position everytime and anytime I need to instantiate 1 die takes its sibling index and get that vector3 postion
    void Awake()
    {
        GameObject currentDiceGroup = Instantiate(buttonAndDicePrefab, transform.position, Quaternion.identity, this.gameObject.transform) as GameObject;
        currentDiceGroup.transform.SetSiblingIndex(0);
        //if(this.gameObject.transform.childCount > 1) ConfigurDiceLocations();
       // totalDiceGroup = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                totalDiceGroup = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        //        totalDiceGroup = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        //Debug.Log("_-----__" + totalDiceGroup.name);
        //ConfigurDiceLocations();
    }

    private void ConfigurDiceLocations()
    {

        //4 create it
        //DiceLocationConfig diceLocationConfig = new DiceLocationConfig(totalDiceGroup.transform.GetChild(0).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(1).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(2).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(3).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(4).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(5).gameObject.transform.position);
        //DiceLocationConfig diceLocationConfig = new DiceLocationConfig();
        //diceLocationConfig.diePosition[0] = new Vector3(totalDiceGroup.transform.GetChild(0).gameObject.transform.position.x, totalDiceGroup.transform.GetChild(0).gameObject.transform.position.y, totalDiceGroup.transform.GetChild(0).gameObject.transform.position.z);
        diceLocationConfig.diePosition[0] = new Vector3(3.34f, 0f,0f );
        diceLocationConfig.diePosition[1] = new Vector3(5.03f,0f,0f);
        diceLocationConfig.diePosition[2] = new Vector3(3.53f,0, 1.61f);
        diceLocationConfig.diePosition[3] = new Vector3(1.89f,0f, 1.61f);
        diceLocationConfig.diePosition[4] = new Vector3(0.34f,0, -0.13f);
        diceLocationConfig.diePosition[5] = new Vector3(0.34f,0,1.35f);
        Debug.Log("------ " + diceLocationConfig.diePosition[0]);
    }
}
