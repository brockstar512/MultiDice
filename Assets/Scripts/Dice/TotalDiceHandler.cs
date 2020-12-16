using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

    //add a game object that shows what score is that round so its [totalscore]+ score
    //public Text potentialPoints;
    //public ChangePlayerController changePlayerController;

    //[SerializeField] GameObject buttonHander;
    //[SerializeField] GameObject scoreRollButton;
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
    //might need to change these to a dictionary
    //lets say you have three two , its going to put the two in the pairs when it reaches 2 twos then again 3 twos.. so it will have two in the pairs twice
    //im going to change it to equal instead of >= but consider changing to a dictionary
    //weird scoring
    List<string> threePairsList = new List<string>();
    List<string> twoTriplesList = new List<string>();
    List<string> fourOfAKindList = new List<string>();
    List<string> fiveOfAKindList = new List<string>();
    List<string> sixOfAKindList = new List<string>();
    List<string> pairForFourOfAKindList = new List<string>();

    [Header(".Find GameObjects")]
    GameObject display;//potential points is 1//4th child
    //GetComponent<ChangePlayerController>().MyFunction();
    GameObject scorePlusEndButtons;
    //1st child


    public int activeButtonCount = 0;

    public ChangePlayerController displayPlayerChanger;//this

    void Awake()
    {
        display = GameObject.Find("Display");
        scorePlusEndButtons = GameObject.Find("ScorePlusEndButtons");
        scorePlusEndButtons.SetActive(false);
    }

    void Update()
    {
        //destroy the dice then run a function that runs the dice iterator
        //Debug.Log("ASSESS WITH BUTTONS" + "Six = " + six + " Five = " + five + " Four = " + four + " Three = " + three + " Two = " + two + " One = " + one);
        //Debug.Log("ASSESS WITH BUTTONS" + "threePairsList = " + threePairsList.Count + " twoTriplesList = " + twoTriplesList.Count + " fourOfAKindList = " + fourOfAKindList.Count + " fiveOfAKindList = " + fiveOfAKindList.Count + " sixOfAKindList = " + sixOfAKindList.Count + "  pairForFourOfAKindList = " + pairForFourOfAKindList.Count);
    }
    public void KeepDiceAndScore()
    {
        Debug.Log("here is the length of total dice " + totalDice.Length);
        foreach (Dice die in totalDice)
        {
            if (die.stay)
            {
                Scoring(die.diceValue);
                //stops scoring dice that haven't veen selected this round
                die.stay = false;
                Debug.Log(" here is what the dice is registering as  = "+die.diceValue);
            }
        }
        //once this function is done iterating you want to cumulate score
        Score();
        //here
        scorePlusEndButtons.transform.GetChild(1).gameObject.SetActive(false);
        //scoreRollButton.SetActive(false);
        scorePlusEndButtons.SetActive(false);
        ButtonController.somethingIsSelected = false;
        //Array.Clear(totalDice, 0, totalDice.Length);
    }

    private void Scoring(int diceValue)
    {
        //some reason some of the larger numbers go negative when I press the button. I think it had to do with the lists.

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
        //Debug.Log("ASSESS WITH BUTTONS" + "Six = " + six + " Five = " + five + " Four = " + four + " Three = " + three + " Two = " + two + " One = " + one);

        //do it this way but also make sure there's a boolean to prevent it from being duplicated
        //or run a for loop that remove duplicate values
        //1. use dictionary becuase I want them to be uniqe, but 2 use list because I want to remove them by there odrer so i can subract the number
        // i and j iteration at the end for each weird button
        //might move this to scoring

        //**EITHER MAKE THIS A SWITCH BECAUSE SWITCHES ARE LITERAL or move this if to score()
        //i could have a method at the end of each switch that takes in a number and calculates it
        //i think the eaqsiest would be do the if statement in the scoreing and run the duplicate function just in case
        //i dont want a switch because the numbers have to be literal so I can t do >= to and its going to break out
        //before it get t the lower weird point systen
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
        if (four == 5)
        {
            fiveOfAKindList.Add("four");
        }
        if (four >= 6)
        {
            sixOfAKindList.Add("four");
        }
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
        //***********************************
        //

        //print("here are the value selected"+six + five + four + three + two + one);
    }

    public void Score()
    {
        //i dont want a switch because the numbers have to be literal so I can t do >= to and its going to break out
        //before it get t the lower weird point systen
        threePairsList = threePairsList.Distinct().ToList();
        twoTriplesList = twoTriplesList.Distinct().ToList();
        fourOfAKindList = fourOfAKindList.Distinct().ToList();
        fiveOfAKindList = fiveOfAKindList.Distinct().ToList();
        sixOfAKindList = sixOfAKindList.Distinct().ToList();
        pairForFourOfAKindList = pairForFourOfAKindList.Distinct().ToList();


        bool hasScored = false;
        //Debug.Log("RUNNING SCORE");
        print("ASSESS WITH BUTTONS" + "Six = "+ six + " Five = " + five + " Four = " + four + " Three = " + three + " Two = " + two + " One = " + one);
        if(one >= 1 && two >= 1 && three >= 1 && four >= 1 && five >= 1 && six >= 1&& activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleSix");
            buttonOneToSixStraight.SetActive(true);
            activeButtonCount++;
        }
        if(twoTriplesList.Count >= 2 && activeButtonCount < 3)
        {
            //Debug.Log("ButtonTwoTriplets");
            buttonTwoTriplets.SetActive(true);
            activeButtonCount++;
        }
        if (pairForFourOfAKindList.Count >= 1 && fourOfAKindList.Count >= 1 && activeButtonCount < 3)
        {
            //Debug.Log("buttonFourOfAkindWithPair");
            buttonFourOfAkindWithPair.SetActive(true);
            activeButtonCount++;
        }
        if (threePairsList.Count >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonThreePairs");
            buttonThreePairs.SetActive(true);
            activeButtonCount++;
        }
        if (sixOfAKindList.Count >=1 && activeButtonCount < 3)
        {
            //Debug.Log("buttonSixOfAKind");
            buttonSixOfAKind.SetActive(true);
            activeButtonCount++;
        }
        if (fiveOfAKindList.Count >= 1 && activeButtonCount < 3)
        {
            //Debug.Log("buttonFiveOfAKind");
            buttonFiveOfAKind.SetActive(true);
            activeButtonCount++;
        }
        if (fourOfAKindList.Count >= 1 && activeButtonCount < 3)
        {
            //Debug.Log("buttonFourOfAKind");
            buttonFourOfAKind.SetActive(true);
            activeButtonCount++;
        }
        if (six >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleSix");
            buttonTripleSix.SetActive(true);
            activeButtonCount++;
        }
        if (five >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleFive");
            buttonTripleFive.SetActive(true);
            activeButtonCount++;
        }
        if (four >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleFour");
            buttonTripleFour.SetActive(true);
            activeButtonCount++;
        }
        if (three >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleThree");
            buttonTripleThree.SetActive(true);
            activeButtonCount++;
        }
        if (one >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleOnes");
            buttonTripleOnes.SetActive(true);
            activeButtonCount++;
        }
        if (two >= 3 && activeButtonCount < 3)
        {
            //Debug.Log("buttonTripleTwo");
            buttonTripleTwo.SetActive(true);
            activeButtonCount++;
        }
        if (one >= 1 && activeButtonCount < 3)
        {
            //Debug.Log("buttonSingleOne");
            buttonSingleOne.SetActive(true);
            activeButtonCount++;
        }
        if (five >= 1 && activeButtonCount < 3)
        {
            //Debug.Log("buttonSingleFive");
            buttonSingleFive.SetActive(true);
            activeButtonCount++;
        }
        if (score > 0 && activeButtonCount == 0) { 
            totalScore += score;
            //changePlayerController.PotentialPointsUIUpdate(totalScore);//this is adding all the total score to the UI after your done calculating the role
            display.GetComponent<ChangePlayerController>().PotentialPointsUIUpdate(totalScore);
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

    public void GameOver()
    {
            scorePlusEndButtons.SetActive(false);
            //Debug.Log("GAME OVER FUNCTION YOU LOST");
            displayPlayerChanger.RolledNewScore(-1);
            displayPlayerChanger.NextPlayer();
            score = 0;
            totalScore = 0;
        ScoreReset();
    }
    public void KeepScoreNextRound()
    {
        //if you have enough point good! Otherwise game over for you
        if (totalScore > 100){
            //should be 499
            //add a variable that shows how the numbers are going to add if they keep going next to display score have a + total score that is this total score
            displayPlayerChanger.RolledNewScore(totalScore);
            totalScore = 0;//this will reset total score fo the next player
            displayPlayerChanger.NextPlayer();
            KeepScoreAndEndRoundButton.SetActive(false);
            keepRollingButton.SetActive(false);
        }
        else{
            KeepScoreAndEndRoundButton.SetActive(false);
            keepRollingButton.SetActive(false);
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
        Debug.Log("Score reset is running");
        //reset lists too
        threePairsList.Clear();
        twoTriplesList.Clear();
        fourOfAKindList.Clear();
        fiveOfAKindList.Clear();
        sixOfAKindList.Clear();
        pairForFourOfAKindList.Clear();

        one = 0;
        two = 0;
        three = 0;
        four = 0;
        five = 0;
        six = 0;
        score = 0;
        if(totalScore > 100) { 
            KeepScoreAndEndRoundButton.SetActive(true);
            keepRollingButton.SetActive(true);
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
                //Debug.Log("2 this function should not be running");
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


    //I NEED TO RESET EVERY ROLL
}
