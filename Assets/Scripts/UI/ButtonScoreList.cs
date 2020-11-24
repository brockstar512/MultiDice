using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScoreList : MonoBehaviour
{
    //[Header("Score Buttons")]
    public GameObject buttonParent;
    

    public TotalDiceHandler totalDiceHandler;
    //add the appropritate buttons and MANAGE LEFT OVER BUTTONS THAT DIDNT SCORE...AND FIX THE NAME THING THAT STORES DATA. IT SHOULD NOT BE THAT
    public void ButtonOne()
    {
        Debug.Log("ACTIVE BUTTON COUNT " + totalDiceHandler.activeButtonCount);

        //add thescore
        //ADD THE SCORE
        //deactivate all the buttons
        DeactivateButtons();//deactivates all buttons
        totalDiceHandler.one--;
        totalDiceHandler.activeButtonCount = 0;//zeroes out which buttons are active
        totalDiceHandler.Score();//rerencer the buttons
    }
    public void ButtonTwo()
    {

    }

    public void ButtonThree()
    {

    }
    public void ButtonFour()
    {

    }
    public void ButtonFive()
    {

    }
    public void ButtonSix()
    {

    }

    //1
    public void TwoTriplets()
    {
        //2500
    }
    //2
    public void OneToSixStraight()
    {
        //1500
    }
    //3
    public void FourOfAkindWithPair()
    {
        //1500
    }
    //4
    public void ThreePairs()
    {
        //1500
    }
    //5
    public void SixOfAKind()
    {
        //3000
    }
    //6
    public void FiveOfAKind()
    {
        //2000
    }
    //7
    public void FourOfAKind()
    {
        //1000
    }
    //8
    public void TripleSix()
    {
        //600
    }
    //9
    public void TripleFive()
    {
        //500
    }
    //10
    public void TripleFour()
    {
        //400
    }
    //11
    public void TripleThree()
    {
        //300
    }
    //12
    public void TripleOnes()
    {
        //300
    }
    //13
    public void TripleTwo()
    {
        //200
    }
    //14
    public void SingleOne()
    {
        //100
    }
    //15
    public void SingleFive()
    {
        //50
    }


    public void DeactivateButtons()
    {
        for (int i = 0; i < buttonParent.transform.childCount; i++)
        {
            var child = buttonParent.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }
    }

}
