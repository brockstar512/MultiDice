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
    //

    //1
    public void TwoTriplets()
    {
        //2500
    }
    //2
    public void OneToSixStraight()
    {
        //1500
        DeactivateButtons();
        totalDiceHandler.one--;
        totalDiceHandler.two--;
        totalDiceHandler.three--;
        totalDiceHandler.four--;
        totalDiceHandler.five--;
        totalDiceHandler.six--;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 1500;
        totalDiceHandler.Score();
    }
    //3
    public void FourOfAkindWithPair()
    {
        //1500
        //totalDiceHandler.
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
        DeactivateButtons();
        //totalDiceHandler.one--;
        //figure out what i have as four of a kind
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 1000;
        totalDiceHandler.Score();
    }
    //8
    public void TripleSix()
    {
        //600
        DeactivateButtons();
        totalDiceHandler.six-=3;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 600;
        totalDiceHandler.Score();
    }
    //9
    public void TripleFive()
    {
        //500
        DeactivateButtons();
        totalDiceHandler.five-=3;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 500;
        totalDiceHandler.Score();
    }
    //10
    public void TripleFour()
    {
        //400
        DeactivateButtons();
        totalDiceHandler.four-=3;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 400;
        totalDiceHandler.Score();
    }
    //11
    public void TripleThree()
    {
        //300
        DeactivateButtons();
        totalDiceHandler.three-=3;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 300;
        totalDiceHandler.Score();
    }
    //12
    public void TripleOnes()
    {
        //300
        DeactivateButtons();
        totalDiceHandler.one-=3;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 300;
        totalDiceHandler.Score();
    }
    //13
    public void TripleTwo()
    {
        //200
        DeactivateButtons();
        totalDiceHandler.two-=3;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 200;
        totalDiceHandler.Score();
    }
    //14
    public void SingleOne()
    {
        //100
        DeactivateButtons();
        totalDiceHandler.one--;
        totalDiceHandler.activeButtonCount = 0;
        totalDiceHandler.score += 100;
        totalDiceHandler.Score();
    }
    //15
    public void SingleFive()
    {
        //50
        DeactivateButtons();//deactivates all buttons
        totalDiceHandler.five--;
        totalDiceHandler.activeButtonCount = 0;//zeroes out which buttons are active
        totalDiceHandler.score += 50;
        totalDiceHandler.Score();//rerencer the buttons
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
