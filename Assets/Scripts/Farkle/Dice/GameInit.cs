using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//should you make the class static or the instance of the class static?
public class GameInit : MonoBehaviour
{
    public GameObject buttonAndDicePrefab;
    public GameObject totalDiceGroup;
    public static DiceLocationConfig diceLocationConfig = new DiceLocationConfig();//3 declare
    public GameObject singleDice;
    public GameObject currentDiceGroup;

    void Awake()
    {
        Debug.Log("GAME INIT -> " + this.gameObject.name);
       currentDiceGroup = Instantiate(buttonAndDicePrefab, transform.position, Quaternion.identity, this.gameObject.transform) as GameObject;
       currentDiceGroup.transform.SetSiblingIndex(0);
        ConfigurDiceLocations();

    }

    private void ConfigurDiceLocations()
    {
        //
        var firstDice = currentDiceGroup.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        var secondDice= currentDiceGroup.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        var thirdDice= currentDiceGroup.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
        var fourthDice= currentDiceGroup.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
        var fifthDice= currentDiceGroup.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject;
        var sixthDice= currentDiceGroup.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject;

        //Debug.Log();
        //4 create it
        diceLocationConfig.diePosition[0] = new Vector3(firstDice.transform.position.x, firstDice.transform.position.y, firstDice.transform.position.z);
        diceLocationConfig.diePosition[1] = new Vector3(secondDice.transform.position.x, secondDice.transform.position.y, secondDice.transform.position.z);
        diceLocationConfig.diePosition[2] = new Vector3(thirdDice.transform.position.x, thirdDice.transform.position.y, thirdDice.transform.position.z);
        diceLocationConfig.diePosition[3] = new Vector3(fourthDice.transform.position.x, fourthDice.transform.position.y, fourthDice.transform.position.z);
        diceLocationConfig.diePosition[4] = new Vector3(fifthDice.transform.position.x, fifthDice.transform.position.y, fifthDice.transform.position.z);
        diceLocationConfig.diePosition[5] = new Vector3(sixthDice.transform.position.x, sixthDice.transform.position.y, sixthDice.transform.position.z);
        //Debug.Log(diceLocationConfig.diePosition[0].x);
        //Debug.Log(diceLocationConfig.diePosition[0].y);
        //Debug.Log(diceLocationConfig.diePosition[0].z);
        Debug.Log("LP:"+fifthDice.transform.localPosition);
        Debug.Log("P:" + fifthDice.transform.position);


    }
}
//me trying to create the locaions through a constructor
//DiceLocationConfig diceLocationConfig = new DiceLocationConfig(totalDiceGroup.transform.GetChild(0).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(1).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(2).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(3).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(4).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(5).gameObject.transform.position);