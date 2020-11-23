using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScoreList : MonoBehaviour
{

    public GameObject buttonParent;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject buttonFour;
    public GameObject buttonFive;
    public GameObject buttonSix;

    public TotalDiceHandler totalDiceHandler;

    public void ButtonOne()
    {
        Debug.Log("ACTIVE BUTTON COUNT " + totalDiceHandler.activeButtonCount);

        //add thescore
        //deactivate all the buttons
        DeactivateButtons();//deactivates all buttons
        totalDiceHandler.TakeAwayDice(1);//take away the correct number of dice you're choosing
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

    public void DeactivateButtons()
    {
        for (int i = 0; i < buttonParent.transform.childCount; i++)
        {
            var child = buttonParent.transform.GetChild(i).gameObject;
            child.SetActive(false);
            //if (child.transform.GetSiblingIndex() != indexOfCurrentButton)
            //{
            //    child.SetActive(false);
            //}
        }
    }

}
