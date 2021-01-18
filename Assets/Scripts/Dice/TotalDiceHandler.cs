using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TotalDiceHandler : MonoBehaviour
{
    //things to do
    //-allowing the phone to roll the dice with the gyroscope
    //-figure out how to determines who wins
    //-figure out messageing system
    //-fix pairs and four of a kind and make sure the buttons rerender when clicked for the more complex buttons
    //-points need to carry over when you roll all your dice and roll again

    public GameInit gameInit;

    public int totalScore;
    List<int> diceSelected = new List<int>();
    //public Dice[] totalDice;
    public List<Dice> totalDice2;
    static public bool roundOver = false;
    public int score = 0;
    public int one = 0;
    public int two = 0;
    public int three = 0;
    public int four = 0;
    public int five = 0;
    public int six = 0;
    public int diceLeft = 0;//this is for false selection
    private int diceToContinue;



    //public Text potentialPoints;
    //public ChangePlayerController changePlayerController;
    public GameObject endRoundButton;
    [SerializeField] GameObject scoreRollButton;
    [SerializeField] GameObject KeepScoreAndEndRoundButton;
    public GameObject keepRollingButton;

    public GameObject diceSingle;


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

    public ChangePlayerController displayPlayerChanger;

    void Awake()
    {
        display = GameObject.Find("Display");
        displayPlayerChanger = display.GetComponent<ChangePlayerController>();
        KeepScoreAndEndRoundButton.SetActive(false);
        gameInit = this.gameObject.transform.parent.GetComponent<GameInit>();
        

    }
    public void KeepDiceAndScore()
    {
        foreach (Dice die in totalDice2)
        {
            if (die.stay)
            {
                Scoring(die.diceValue);
                die.stay = false;
                diceLeft++;
            }
        }
        Score();
        scoreRollButton.SetActive(false);
        ButtonController.somethingIsSelected = false;
        endRoundButton.transform.parent.gameObject.SetActive(false);
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
    }


    public void Score()
    {
        diceToContinue = this.gameObject.transform.childCount;
        ShowDice(false);

        //need to check for of a if with a pair... pair might be read as whats in four of a kind
        threePairsList = threePairsList.Distinct().ToList();
        twoTriplesList = twoTriplesList.Distinct().ToList();
        fourOfAKindList = fourOfAKindList.Distinct().ToList();
        fiveOfAKindList = fiveOfAKindList.Distinct().ToList();
        sixOfAKindList = sixOfAKindList.Distinct().ToList();
        pairForFourOfAKindList = pairForFourOfAKindList.Distinct().ToList();

        bool hasScored = false;
        print("ASSESS WITH BUTTONS" + "Six = "+ six + " Five = " + five + " Four = " + four + " Three = " + three + " Two = " + two + " One = " + one);
        if(one >= 1 && two >= 1 && three >= 1 && four >= 1 && five >= 1 && six >= 1&& activeButtonCount < 3)
        {
            buttonOneToSixStraight.SetActive(true);
            activeButtonCount++;
        }
        if(twoTriplesList.Count >= 2 && activeButtonCount < 3)
        {
            buttonTwoTriplets.SetActive(true);
            activeButtonCount++;
        }
        if (pairForFourOfAKindList.Count >= 1 && fourOfAKindList.Count >= 1 && activeButtonCount < 3)
        {
            buttonFourOfAkindWithPair.SetActive(true);
            activeButtonCount++;
        }
        if (threePairsList.Count >= 3 && activeButtonCount < 3)
        {
            buttonThreePairs.SetActive(true);
            activeButtonCount++;
        }
        if (sixOfAKindList.Count >=1 && activeButtonCount < 3)
        {
            buttonSixOfAKind.SetActive(true);
            activeButtonCount++;
        }
        if (fiveOfAKindList.Count >= 1 && activeButtonCount < 3)
        {
            buttonFiveOfAKind.SetActive(true);
            activeButtonCount++;
        }
        if (fourOfAKindList.Count >= 1 && activeButtonCount < 3)
        {
            buttonFourOfAKind.SetActive(true);
            activeButtonCount++;
        }
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
        if (score > 0 && activeButtonCount == 0) { 
            totalScore += score;
            display.GetComponent<ChangePlayerController>().PotentialPointsUIUpdate(totalScore);
            

            if (score <= 100 && totalScore <= 100)
            {                
                DestroyExistingDice();
                addSingleDice(diceToContinue);
                if(diceLeft > 0 && score > 0){
                addSingleDice(diceLeft,true);
                diceLeft = 0;
                }


            }
            ScoreReset();
            //ClearEmptyArraySlots();
        }
        else if(score <= 0 && activeButtonCount == 0 && !hasScored)
        {
            
            Debug.Log("GAME OVER");
            GameOver();
        }


    }

    public void GameOver()
    {
        KeepScoreAndEndRoundButton.SetActive(false);
        //displayPlayerChanger.RolledNewScore(-1);
        displayPlayerChanger.FarkledCounter(1);
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
            displayPlayerChanger.RolledNewScore(totalScore);
            displayPlayerChanger.FarkledCounter(0);
            totalScore = 0;
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

    public void addSingleDice( int dicePutBack, bool leftOver = false)
    {

        while (dicePutBack > 0)
        { 
            GameObject newDie;
            if(!leftOver){
                 newDie = Instantiate(diceSingle, GameInit.diceLocationConfig.diePosition[dicePutBack -1], Quaternion.identity) as GameObject;
                newDie.transform.SetParent(transform, false);
            }
            else{

                newDie = Instantiate(diceSingle, GameInit.diceLocationConfig.diePosition[6 - dicePutBack], Quaternion.identity) as GameObject;
                newDie.transform.SetParent(transform, false);
                 
            }
            totalDice2.Add(newDie.transform.GetChild(0).GetComponent<Dice>());
            dicePutBack--;
        }
        
    }

    public void InformDiceRoundOver()
    {
        foreach( Dice die in totalDice2)
        {
            if(die != null)
            {
                die.roundOver();
            }
        }
    }

    public void DestroyExistingDice()
    {
       for(int i = 0; i < this.gameObject.transform.childCount;i++){
           Destroy(this.gameObject.transform.GetChild(i).gameObject);
       }
    }

    public void KeepRolling()
    {
        KeepScoreAndEndRoundButton.SetActive(false);
        keepRollingButton.SetActive(false);
        if (this.gameObject.transform.childCount == 0)
        {
            display.GetComponent<ChangePlayerController>().CarryScoreForNewDice(totalScore);//? i think this will do it
            display.GetComponent<ChangePlayerController>().ReactivateDice();
            //give variable to display that is carryOverPoints... that equals to 0. you are passing over points.
            //everytime you add points you make it zero so you only add it once to the over all points
            //
        }
        else { 
            DestroyExistingDice();
            addSingleDice(diceToContinue);
            if(diceLeft > 0){
                addSingleDice(diceLeft,true);
                diceLeft = 0;
                } 
            }
    }

    private void ShowDice(bool show)
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(show);
        }
    }

    //private void ClearEmptyArraySlots()
    //{
    //    for(int i = 0; i < totalDice2.Count; i++)
    //    {
    //        Debug.Log("here is i    "+ i+"  here is whats at i  " + totalDice2[i]);
    //        if(totalDice2[i]== null) { totalDice2.RemoveAt(i); }
    //        totalDice2.Remove(null);
    //    }
    //}

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
}
