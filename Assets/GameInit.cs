using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//should you make the class static or the instance of the class static?
public class GameInit : MonoBehaviour
{
    public GameObject buttonAndDicePrefab;
    public GameObject totalDiceGroup;
    public static DiceLocationConfig diceLocationConfig = new DiceLocationConfig();//3 declare
    //public DiceLocationConfig diceLocationConfig = new DiceLocationConfig();//3 declare
    public GameObject singleDice;
    public GameObject currentDiceGroup;

    void Update()
    {
        //i dont want to reference this prefab. i want to reference something else maybe even button anddiceprefab then the total dice in that
        //Debug.Log(currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.localPosition.x);
        //Debug.Log(totalDiceGroup.transform.GetChild(0).gameObject.name);
        //Debug.Log("1->"+diceLocationConfig.diePosition[0]);
        //Debug.Log("2->" + diceLocationConfig.diePosition[1]);
        //Debug.Log("3->" + diceLocationConfig.diePosition[2]);
        //Debug.Log("4->" + diceLocationConfig.diePosition[3]);
        //Debug.Log("5->" + diceLocationConfig.diePosition[4]);
        //Debug.Log("6->" + diceLocationConfig.diePosition[5]);
    }
    //serialize position of the die
    //instantiate all of the die and get get there position
    //that way all of the dice will have the same position everytime and anytime I need to instantiate 1 die takes its sibling index and get that vector3 postion
    void Awake()
    {
       currentDiceGroup = Instantiate(buttonAndDicePrefab, transform.position, Quaternion.identity, this.gameObject.transform) as GameObject;
       currentDiceGroup.transform.SetSiblingIndex(0);

        //if(this.gameObject.transform.childCount > 1) ConfigurDiceLocations();
       // totalDiceGroup = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                //totalDiceGroup = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        //        totalDiceGroup = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        //Debug.Log("_-----__" + totalDiceGroup.name);
        ConfigurDiceLocations();


        //---------- testing purposes...
        //GameObject die = Instantiate(singleDice, diceLocationConfig.diePosition[4], Quaternion.identity) as GameObject;
        //transform.SetSiblingIndex(0);
        //die.transform.SetParent(transform, false);

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
        //DiceLocationConfig diceLocationConfig = new DiceLocationConfig(totalDiceGroup.transform.GetChild(0).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(1).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(2).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(3).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(4).gameObject.transform.position,
        //    totalDiceGroup.transform.GetChild(5).gameObject.transform.position);
        //DiceLocationConfig diceLocationConfig = new DiceLocationConfig();
        //diceLocationConfig.diePosition[0] = new Vector3(totalDiceGroup.transform.GetChild(0).gameObject.transform.position.x, totalDiceGroup.transform.GetChild(0).gameObject.transform.position.y, totalDiceGroup.transform.GetChild(0).gameObject.transform.position.z);
        //diceLocationConfig.diePosition[0] = new Vector3(currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.localPosition.x, currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.localPosition.y, currentDiceGroup.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.localPosition.z);
        diceLocationConfig.diePosition[0] = new Vector3(firstDice.transform.localPosition.x, firstDice.transform.localPosition.y, firstDice.transform.localPosition.z);
        diceLocationConfig.diePosition[1] = new Vector3(secondDice.transform.localPosition.x, secondDice.transform.localPosition.y, secondDice.transform.localPosition.z);
        diceLocationConfig.diePosition[2] = new Vector3(thirdDice.transform.localPosition.x, thirdDice.transform.localPosition.y, thirdDice.transform.localPosition.z);
        diceLocationConfig.diePosition[3] = new Vector3(fourthDice.transform.localPosition.x, fourthDice.transform.localPosition.y, fourthDice.transform.localPosition.z);
        diceLocationConfig.diePosition[4] = new Vector3(fifthDice.transform.localPosition.x, fifthDice.transform.localPosition.y, fifthDice.transform.localPosition.z);
        diceLocationConfig.diePosition[5] = new Vector3(sixthDice.transform.localPosition.x, sixthDice.transform.localPosition.y, sixthDice.transform.localPosition.z);
        //Debug.Log("------ " + diceLocationConfig.diePosition[0]);
    }
}
//instantiate the dice properly
//then work on making the vector 3 static