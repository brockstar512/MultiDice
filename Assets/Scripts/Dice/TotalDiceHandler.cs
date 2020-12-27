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

    //public Text potentialPoints;
    //public ChangePlayerController changePlayerController;

    [SerializeField] GameObject scoreRollButton;
    [SerializeField] GameObject KeepScoreAndEndRoundButton;
    public GameObject keepRollingButton;    



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


    List<string> threePairsList = new List<string>();
    List<string> twoTriplesList = new List<string>();
    List<string> fourOfAKindList = new List<string>();
    List<string> fiveOfAKindList = new List<string>();
    List<string> sixOfAKindList = new List<string>();
    List<string> pairForFourOfAKindList = new List<string>();

    [Header(".Find GameObjects")]
    GameObject display;




    public int activeButtonCount = 0;

    public ChangePlayerController displayPlayerChanger;//this

    void Awake()
    {
        display = GameObject.Find("Display");
        displayPlayerChanger = display.GetComponent<ChangePlayerController>();
        KeepScoreAndEndRoundButton.SetActive(false);
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
        Score();

        //scorePlusEndButtons.transform.GetChild(1).gameObject.SetActive(false);
        scoreRollButton.SetActive(false);
        //scorePlusEndButtons.SetActive(false);
        ButtonController.somethingIsSelected = false;
        //**figure out what is the end round button and when is the keep score buttons

        //end round after i roll
        //if something is selected end round turns off and score is active
        //once you click score roll, score roll should turn off and when
        //scoring is done you have end round and keep score button if are are more than X and the
        //other button is keep rolling


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
        //this is a different function?
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
            pairForFourOfAKindList.Remove("six");
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
            pairForFourOfAKindList.Remove("five");
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
            pairForFourOfAKindList.Remove("four");
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
            pairForFourOfAKindList.Remove("three");
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
            pairForFourOfAKindList.Remove("two");
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
            pairForFourOfAKindList.Remove("one");

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
    //private void WeirdButtonPairing()
    //{
    //run this function when you subract the buttons
    //it might leave the subract weird button function redundant but 
    //}

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
        //figure out how to handle this... if you have four of a kind you will have the same number as a pair too
        //what if where its sorting four of a kind list ut renices us as a pair from the list
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
        }

    }

    public void GameOver()
    {//working on here right now
            KeepScoreAndEndRoundButton.SetActive(false);
        displayPlayerChanger.RolledNewScore(-1);
        //display.GetComponent<ChangePlayerController>().RolledNewScore(-1);
        displayPlayerChanger.NextPlayer();
        //display.GetComponent<ChangePlayerController>().NextPlayer();
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
    //i need to make a function that removes the corresponding numbers out of the lower lists
    //maybe clear the buttons and run the function that figures out the lists again in a seperate function
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
                //threePairsList.Remove(six);
                //i could do this but its more effective to do it the other way. where I run the button function agauin
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

    public void AWeirdButtonWasPressed( string valueToTakeOut)
    {
        foreach(string dieValue in threePairsList)
        {
            if(dieValue == valueToTakeOut) { threePairsList.Remove(valueToTakeOut); }
            //seems like I could just remove() method
        }
        //threePairsList
        //twoTriplesList
        //fourOfAKindList
        //fiveOfAKindList
        //sixOfAKindList
        //pairForFourOfAKindList
        //
        //when five of a kind is pressed i need to take out that same number out of the pair and four of a kind
    }

   public void NextPlayer()
    {
        //display
    }
}
