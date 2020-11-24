using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalDiceHandler : MonoBehaviour
{
    public int totalScore;
    List<int> diceSelected = new List<int>();
    public Dice[] totalDice;
    static public bool roundOver = false;
    int score = 0;
    public int one = 0;
    public int two = 0;
    public int three = 0;
    public int four = 0;
    public int five = 0;
    public int six = 0;


    [SerializeField] GameObject buttonHander;
    [SerializeField] GameObject scoreRollButton;

    [Header("Score Buttons")]
    public GameObject buttonParent;
    public GameObject buttonTwoTriplets;
    public GameObject buttonOneToSixStraight;
    public GameObject buttonFourOfAkindWithPair;
    public GameObject buttonThreePairs;
    public GameObject buttonSixOfAKind;
    public GameObject buttonFiveOfAKind;
    public GameObject buttonFourOfAKind;
    public GameObject buttonTripleSix;
    public GameObject buttonTripleFive;
    public GameObject buttonTripleFour;
    public GameObject buttonTripleThree;
    public GameObject buttonTripleOnes;
    public GameObject buttonTripleTwo;
    public GameObject buttonSingleOne;
    public GameObject buttonSingleFive;




    public int activeButtonCount = 0;

    public Display displayPlayerChanger;

    void Awake()
    {
        buttonHander.SetActive(false);
    }

    public void KeepDiceAndScore()
    {
        foreach (Dice die in totalDice)
        {
            if (die.stay)
            {
                Scoring(die.diceValue);
                //stops scoring dice that haven't veen selected this round
                die.stay = false;
            }
        }
        //once this function is done iterating you want to cumulate score
        Score();
        scoreRollButton.SetActive(false);
        buttonHander.SetActive(false);
        ButtonController.somethingIsSelected = false;
    }

    private void Scoring(int diceValue)
    {

        switch (diceValue)
        {
            case 6:
                six += 1;
                break;
            case 5:
                five += 1;
                break;
            case 4:
                four += 1;
                break;
            case 3:
                three += 1;
                break;
            case 2:
                two += 1;
                break;
            case 1:
                one += 1;
                break;
            default:
                Debug.Log("Danger");
                break;
        }

        print("here are the value selected"+six + five + four + three + two + one);
        
    }

    public void Score()
    {
        bool hasScored = false;
        Debug.Log("RUNNING SCORE");  
        
        //if (one >= 1 && activeButtonCount < 6)
        //{
        //    buttonOne.SetActive(true);
        //    //score++;//i want to increase the score. but i dont think this is necesarry/ this is so i dont get a game over right now
        //    activeButtonCount++;
        //    //return;//return out so you dont run the rest.. I HAD THIS RETURN SO IT DIDNT RUN THE GAME OVER FUNCTION or the ROUND OVER UNTIL EVRYTHING WAS DONE
        //}
        //if (two >= 1 && activeButtonCount < 3)
        //{
        //    buttonTwo.SetActive(true);
        //    activeButtonCount++;
        //}
        //if (three >= 1 && activeButtonCount < 3)
        //{
        //    buttonThree.SetActive(true);
        //    activeButtonCount++;
        //}
        //if (four >= 1 && activeButtonCount < 3)
        //{
        //    buttonFour.SetActive(true);
        //    activeButtonCount++;
        //}
        //if (five >= 1 && activeButtonCount < 3)
        //{
        //    buttonFive.SetActive(true);
        //    activeButtonCount++;
        //}
        //if (six >= 1 && activeButtonCount < 3)
        //{
        //    buttonSix.SetActive(true);
        //    activeButtonCount++;
        //}

        





        if (score > 0 && activeButtonCount == 0) { 
        //if score is greater than 0 do this 
        Debug.Log("YOURE SCORE THIS ROUND IS " + score);
        totalScore += score;
        Debug.Log("YOURE TOTAL SCORE IS" + totalScore);
        ScoreReset();
        }
        else if(score <= 0 && activeButtonCount == 0 && !hasScored)
        {
            Debug.Log("GAME OVER");
            //be sure to make sure to make a function that will skip the player if he is out
            //also be sure that if player selects a die that will not generate point that is re awakens the die
            displayPlayerChanger.NextPlayer();
            score = 0;
            totalScore = 0;
        }
        
    }

    public void ScoreReset()
    {
        one = 0;
        Debug.Log("HERE IS ONE" + one);
        two = 0;
        Debug.Log("HERE IS TWO" + two);
        three = 0;
        Debug.Log("HERE IS THREE" + three);
        four = 0;
        Debug.Log("HERE IS FOUR" + four);
        five = 0;
        Debug.Log("HERE IS FIVE" + five);
        six = 0;
        Debug.Log("HERE IS SIX" + six);
        Debug.Log("YOURE SCORE Reset To  " + 0);
        score = 0;
    }



}
