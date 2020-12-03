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

    //weird scoring
    List<string> threePairsList = new List<string>();
    List<string> twoTriplesList = new List<string>();
    List<string> fourOfAKindList = new List<string>();
    List<string> fiveOfAKindList = new List<string>();
    List<string> sixOfAKindList = new List<string>();
    List<string> pairForFourOfAKindList = new List<string>();


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
                if (six >= 2)
                {
                    threePairsList.Add("six");
                    pairForFourOfAKindList.Add("six");
                }
                if (six >= 3)
                {
                    twoTriplesList.Add("six");
                }
                if (six >= 4)
                {
                    fourOfAKindList.Add("six");
                }
                if (six >= 5)
                {
                    fiveOfAKindList.Add("six");
                }
                if (six >= 6)
                {
                    sixOfAKindList.Add("six");
                }
                break;
            case 5:
                five += 1;
                if (five >= 2)
                {
                    threePairsList.Add("five");
                    pairForFourOfAKindList.Add("five");
                }
                if (five >= 3)
                {
                    twoTriplesList.Add("five");
                }
                if (five >= 4)
                {
                    fourOfAKindList.Add("five");
                }
                if (five >= 5)
                {
                    fiveOfAKindList.Add("five");
                }
                if (five >= 6)
                {
                    sixOfAKindList.Add("five");
                }
                break;
            case 4:
                four += 1;
                if (four >= 2)
                {
                    threePairsList.Add("four");
                    pairForFourOfAKindList.Add("four");
                }
                if (four >= 3)
                {
                    twoTriplesList.Add("four");
                }
                if (four >= 4)
                {
                    fourOfAKindList.Add("four");
                }
                if (four >= 5)
                {
                    fiveOfAKindList.Add("four");
                }
                if (four >= 6)
                {
                    sixOfAKindList.Add("four");
                }
                break;
            case 3:
                three += 1;
                if (three >= 2)
                {
                    threePairsList.Add("three");
                    pairForFourOfAKindList.Add("three");
                }
                if (three >= 3)
                {
                    twoTriplesList.Add("three");
                }
                if (three >= 4)
                {
                    fourOfAKindList.Add("three");
                }
                if (three >= 5)
                {
                    fiveOfAKindList.Add("three");
                }
                if (three >= 6)
                {
                    sixOfAKindList.Add("three");
                }
                break;
            case 2:
                two += 1;
                if (two >= 2)
                {
                    threePairsList.Add("two");
                    pairForFourOfAKindList.Add("two");
                }
                if (two >= 3)
                {
                    twoTriplesList.Add("two");
                }
                if (two >= 4)
                {
                    fourOfAKindList.Add("two");
                }
                if (two >= 5)
                {
                    fiveOfAKindList.Add("two");
                }
                if (two >= 6)
                {
                    sixOfAKindList.Add("two");
                }
                break;
            case 1:
                one += 1;
                if (one >= 2)
                {
                    threePairsList.Add("one");
                    pairForFourOfAKindList.Add("one");
                }
                if (one >= 3)
                {
                    twoTriplesList.Add("one");
                }
                if (one >= 4)
                {
                    fourOfAKindList.Add("one");
                }
                if (one >= 5)
                {
                    fiveOfAKindList.Add("one");
                }
                if (one >= 6)
                {
                    sixOfAKindList.Add("one");
                }
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
        

        if (six >= 3 && activeButtonCount < 3)
        {
            buttonTripleSix.SetActive(true);
            activeButtonCount++;
        }
        if (five >= 3 && activeButtonCount < 3)
        {
            buttonTripleFive.SetActive(true);
            activeButtonCount++;
        }
        if (four >= 3 && activeButtonCount < 3)
        {
            buttonTripleFour.SetActive(true);
            activeButtonCount++;
        }
        if (three >= 3 && activeButtonCount < 3)
        {
            buttonTripleThree.SetActive(true);
            activeButtonCount++;
        }
        if (one >= 3 && activeButtonCount < 3)
        {
            buttonTripleOnes.SetActive(true);
            activeButtonCount++;
        }
        if (two >= 3 && activeButtonCount < 3)
        {
            buttonTripleTwo.SetActive(true);
            activeButtonCount++;
        }
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
        if (totalScore > 499){
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
        if(totalScore > 499) { 
            KeepScoreAndEndRoundButton.SetActive(true);
            keepRollingButton.SetActive(true);
            //what i could do is hide dice when this unhides then, so this also hides them but the button shows them
        }
    }

    public void SubtractTwoTriples()
    {
        switch (twoTriplesList[0])
        {
            case "six":
                six -= 3;
                break;
            case "five":
                five -= 3;
                break;
            case "four":
                four -= 3;
                break;
            case "three":
                three -= 3;
                break;
            case "two":
                two -= 3;
                break;
            case "one":
                one -= 3;
                break;
            default:
                Debug.Log("1 this function should not be running");
                break;
        }
        switch (twoTriplesList[1])
        {
            case "six":
                six -= 3;
                break;
            case "five":
                five -= 3;
                break;
            case "four":
                four -= 3;
                break;
            case "three":
                three -= 3;
                break;
            case "two":
                two -= 3;
                break;
            case "one":
                one -= 3;
                break;
            default:
                Debug.Log("1 this function should not be running");
                break;
        }
        twoTriplesList.Clear();

    }
    public void SubtractSixOfAKind()
    {
        switch(sixOfAKindList[0])
        {
            case "six":
                six -= 6;
                break;
            case "five":
                five -= 6;
                break;
            case "four":
                four -= 6;
                break;
            case "three":
                three -= 6;
                break;
            case "two":
                two -= 6;
                break;
            case "one":
                one -= 6;
                break;
            default:
                Debug.Log("2 this function should not be running");
                break;
        }
        sixOfAKindList.Clear();
    }
    public void SubtractFiveOfAKind()
    {
        switch (fiveOfAKindList[0])
        {
            case "six":
                six -= 5;
                break;
            case "five":
                five -= 5;
                break;
            case "four":
                four -= 5;
                break;
            case "three":
                three -= 5;
                break;
            case "two":
                two -= 5;
                break;
            case "one":
                one -= 5;
                break;
            default:
                Debug.Log("3 this function should not be running");
                break;
        }
        fiveOfAKindList.Clear();
    }
    public void SubtractFourOfAKindListWithPair()
    {
        switch (fourOfAKindList[0])
        {
            case "six":
                six -= 4;
                break;
            case "five":
                five -= 4;
                break;
            case "four":
                four -= 4;
                break;
            case "three":
                three -= 4;
                break;
            case "two":
                two -= 4;
                break;
            case "one":
                one -= 4;
                break;
            default:
                Debug.Log("4 this function should not be running");
                break;
        }
        fourOfAKindList.Clear();

        switch (pairForFourOfAKindList[0])
        {
            case "six":
                six -= 2;
                break;
            case "five":
                five -= 2;
                break;
            case "four":
                four -= 2;
                break;
            case "three":
                three -= 2;
                break;
            case "two":
                two -= 2;
                break;
            case "one":
                one -= 2;
                break;
            default:
                Debug.Log("4b this function should not be running");
                break;
        }
        pairForFourOfAKindList.Clear();
    }
    public void SubtractFourOfAKind()
    {
        switch (fourOfAKindList[0])
        {
            case "six":
                six -= 4;
                break;
            case "five":
                five -= 4;
                break;
            case "four":
                four -= 4;
                break;
            case "three":
                three -= 4;
                break;
            case "two":
                two -= 4;
                break;
            case "one":
                one -= 4;
                break;
            default:
                Debug.Log("5 this function should not be running");
                break;
        }
        fourOfAKindList.Clear();
    }
    public void SubtractThreePairs()
    {
        switch (threePairsList[0])
        {
            case "six":
                six -= 2;
                break;
            case "five":
                five -= 2;
                break;
            case "four":
                four -= 2;
                break;
            case "three":
                three -= 2;
                break;
            case "two":
                two -= 2;
                break;
            case "one":
                one -= 2;
                break;
            default:
                Debug.Log("6 this function should not be running");
                break;
        }
        switch (threePairsList[1])
        {
            case "six":
                six -= 2;
                break;
            case "five":
                five -= 2;
                break;
            case "four":
                four -= 2;
                break;
            case "three":
                three -= 2;
                break;
            case "two":
                two -= 2;
                break;
            case "one":
                one -= 2;
                break;
            default:
                Debug.Log("6b this function should not be running");
                break;
        }
        switch (threePairsList[2])
        {
            case "six":
                six -= 2;
                break;
            case "five":
                five -= 2;
                break;
            case "four":
                four -= 2;
                break;
            case "three":
                three -= 2;
                break;
            case "two":
                two -= 2;
                break;
            case "one":
                one -= 2;
                break;
            default:
                Debug.Log("6c this function should not be running");
                break;
        }
        threePairsList.Clear();
    }


    //private void hideDie()
    //{
    //    //dont need this because its going to reactivate a lot of dice that i want sleeping
    //}



}
