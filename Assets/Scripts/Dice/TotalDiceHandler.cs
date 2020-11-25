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
    public int score = 0;
    public int one = 0;
    public int two = 0;
    public int three = 0;
    public int four = 0;
    public int five = 0;
    public int six = 0;


    [SerializeField] GameObject buttonHander;
    [SerializeField] GameObject scoreRollButton;
    [SerializeField] GameObject KeepScoreAndEndRoundButton;
    public GameObject keepRollingButton;

    //keep score and continue// i should get this out of the parent button object...
    //this should be active when you score point and you don't have any button children available. and total score is above a certain threshold
    

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
        //maybe do a switch for the more complicated buttons
        bool hasScored = false;
        Debug.Log("RUNNING SCORE");

        //if (one >= 1 && activeButtonCount < 6)
        //{
        //    buttonOne.SetActive(true);
        //    //score++;//i want to increase the score. but i dont think this is necesarry/ this is so i dont get a game over right now
        //    activeButtonCount++;
        //    //return;//return out so you dont run the rest.. I HAD THIS RETURN SO IT DIDNT RUN THE GAME OVER FUNCTION or the ROUND OVER UNTIL EVRYTHING WAS DONE
        //}
    
        if (one >= 1 && activeButtonCount < 3)
        {
            buttonSingleOne.SetActive(true);
            activeButtonCount++;
        }
        if (five >= 1 && activeButtonCount < 3)
        {
            buttonSingleFive.SetActive(true);
            activeButtonCount++;
        }
        //if there are two of the same button?



        if (score > 0 && activeButtonCount == 0) { 
            Debug.Log("YOURE SCORE THIS ROUND IS " + score);
            totalScore += score;
            Debug.Log("YOURE TOTAL SCORE IS" + totalScore);
            ScoreReset();
        }
        else if(score <= 0 && activeButtonCount == 0 && !hasScored)
        {
            Debug.Log("GAME OVER");

            GameOver();
            //be sure to make sure to make a function that will skip the player if he is out
            //also be sure that if player selects a die that will not generate point that is re awakens the die
        }

    }

    //CREATE A FUNCTION THAT LETS YOU STOP ROLLING IF YOU WANT TO KEEP YOUR POINTS
    public void GameOver()
    {
            buttonHander.SetActive(false);
            Debug.Log("GAME OVER FUNCTION YOU LOST");
            displayPlayerChanger.NextPlayer();
            score = 0;
            totalScore = 0;
        
    }
    public void KeepScoreNextRound()
    {
        //if you have enough point good! Otherwise game over for you
        if (totalScore > 0){
            displayPlayerChanger.NextPlayer();
            KeepScoreAndEndRoundButton.SetActive(false);
        }
        else{
            KeepScoreAndEndRoundButton.SetActive(false);
            GameOver();
        }
    }

    public void KeepRolling()
    {
        KeepScoreAndEndRoundButton.SetActive(false);
        keepRollingButton.SetActive(false);
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

        KeepScoreAndEndRoundButton.SetActive(true);
        keepRollingButton.SetActive(true);

    }



}
