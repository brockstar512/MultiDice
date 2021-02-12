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
       currentDiceGroup = Instantiate(buttonAndDicePrefab, transform.position, Quaternion.identity, this.gameObject.transform) as GameObject;
       currentDiceGroup.transform.SetSiblingIndex(0);
        ConfigurDiceLocations();

    }

    private void ConfigurDiceLocations()
    {
        var firstDice = currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        var secondDice= currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
        var thirdDice= currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject;
        var fourthDice= currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject;
        var fifthDice= currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject;
        var sixthDice= currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject;


        //4 create it
        diceLocationConfig.diePosition[0] = new Vector3(firstDice.transform.localPosition.x, firstDice.transform.localPosition.y, firstDice.transform.localPosition.z);
        diceLocationConfig.diePosition[1] = new Vector3(secondDice.transform.localPosition.x, secondDice.transform.localPosition.y, secondDice.transform.localPosition.z);
        diceLocationConfig.diePosition[2] = new Vector3(thirdDice.transform.localPosition.x, thirdDice.transform.localPosition.y, thirdDice.transform.localPosition.z);
        diceLocationConfig.diePosition[3] = new Vector3(fourthDice.transform.localPosition.x, fourthDice.transform.localPosition.y, fourthDice.transform.localPosition.z);
        diceLocationConfig.diePosition[4] = new Vector3(fifthDice.transform.localPosition.x, fifthDice.transform.localPosition.y, fifthDice.transform.localPosition.z);
        diceLocationConfig.diePosition[5] = new Vector3(sixthDice.transform.localPosition.x, sixthDice.transform.localPosition.y, sixthDice.transform.localPosition.z);
    }
}
//me trying to create the locaions through a constructor
//DiceLocationConfig diceLocationConfig = new DiceLocationConfig(totalDiceGroup.transform.GetChild(0).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(1).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(2).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(3).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(4).gameObject.transform.position,
//    totalDiceGroup.transform.GetChild(5).gameObject.transform.position);