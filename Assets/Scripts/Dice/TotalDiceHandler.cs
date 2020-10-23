﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDiceHandler : MonoBehaviour
{
    public int totalScore;
    List<int> diceSelected = new List<int>();
    public Dice[] totalDice;
    static public bool roundOver = false;
    int score = 0;
    int one = 0;
    int two = 0;
    int three = 0;
    int four = 0;
    int five = 0;
    int six = 0;


    [SerializeField] GameObject buttonHander;
    [SerializeField] GameObject scoreRollButton;

    void Awake()
    {
        buttonHander.SetActive(false);
    }

    public void KeepDiceAndScore()
    {
        foreach (Dice die in totalDice)//i might need to reset total dice after each round
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

    public void Scoring(int diceValue)
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
        switch(six)
        {
            case 6:
                score += 3000;
                break;
            case 5:
                score += 2000;
                break;
            case 4:
                score += 1000;
                break;
            case 3:
                score += 600;
                break;
            default:
                score += 0;
                break;
        }
        switch (five)
        {
            case 6:
                score += 3000;
                five -= 6;
                break;
            case 5:
                score += 2000;
                break;
            case 4:
                score += 1000;
                break;
            case 3:
                score += 500;
                break;
            case 2:
                score += 100;
                break;
            case 1:
                score += 50;
                break;
            default:
                score+=0;
                break;
        }
        switch (four)
        {
            case 6:
                score += 3000;
                break;
            case 5:
                score += 2000;
                break;
            case 4:
                score += 1000;
                break;
            case 3:
                score += 400;
                break;
            default:
                score += 0;
                break;
        }
        switch (three)
        {
            case 6:
                score += 3000;
                three -= 6;
                break;
            case 5:
                score += 2000;
                three -= 5;
                break;
            case 4:
                score += 1000;
                three -= 4;
                break;
            case 3:
                score += 300;
                three -= 3;
                break;
            default:
                score += 0;
                break;
        }
        switch (two)
        {
            case 6:
                score += 3000;
                two -= 6;
                break;
            case 5:
                score += 2000;
                two -= 5;
                break;
            case 4:
                score += 1000;
                two -= 4;
                break;
            case 3:
                score += 200;
                two -= 3;
                break;
            default:
                score += 0;
                break;
        }
        switch (one)
        {
            case 6:
                score += 3000;
                one -= 6;//insurance so i dont count the roll twice
                break;
            case 5:
                score += 2000;
                one -= 5;
                break;
            case 4:
                score += 1000;
                one -= 4;
                break;
            case 3:
                score += 300;
                one -= 3;
                break;
            case 2:
                score += 200;
                one -= 2;
                break;
            case 1:
                score += 100;
                one -= 1;
                break;
            default:
                score += 0;
                break;
        }

        //one of all kinds
        if ((one.ToString() == "1") && (two.ToString() == "1") && (three.ToString() == "1") && (four.ToString() == "1") && (five.ToString() == "1") && (six.ToString() == "1"))
        {
            score += 1500;
        }

        //three pairs

        if(score > 0) { 
        //if score is greater than 0 do this 
        Debug.Log("YOURE SCORE THIS ROUND IS " + score);
        totalScore += score;
        Debug.Log("YOURE TOTAL SCORE IS" + totalScore);
        ScoreReset();
        }
        else
        {
            Debug.Log("GAME OVER");
        }
        //esle run game over
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
//3 scores
//each round you have a score for that roll
//each game you have a seperate total score for that round where you are perpetually rolling
//each game you have a overall score

//I need a player object that rolls the dice that stores the ammount of dice for each round.