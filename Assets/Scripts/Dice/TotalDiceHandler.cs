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
    int one = 0;
    int two = 0;
    int three = 0;
    int four = 0;
    int five = 0;
    int six = 0;


    [SerializeField] GameObject buttonHander;
    [SerializeField] GameObject scoreRollButton;

    public GameObject buttonParent;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject buttonFour;
    public GameObject buttonFive;
    public GameObject buttonSix;

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
        //what if I pass a button score handler to this and it assess what buttons to activate
        //or I can just keep it all here. that way if it chooses a button it can zero out the important variables and rerun

        
        
    }
    public void Score()
    {
        Debug.Log("RUNNING SCORE");  
        //create buttons for each possible score starting from highest to lowest
        //each button should add the score they have
        //reset the values that it takes from the dice
        //and recursivly checks this score again
        //so that when it gets to the bottom it checks the current round score you got and if it gets the the bottom and there is a score it just resets
        //if you didnt get a score do whatever happens when you're suppose to get a game over
        //only show a button if the child count is less than 6 so its not overwhelmed by buttons
        //consider doing something with a dice if it was never counted


        //in game over i need to set each child of what is holding the dice to true so that all the dice are on and
        //i need to change the player

        //buttons parent =
        //if buttons parent.childcount is less then 6

        //deactivate button parents children-- no deactive all children when you press the buttn
        //deactive childs
        //for (int i = 0; i < buttonParent.transform.childCount; i++)
        //{
        //    var child = buttonParent.transform.GetChild(i).gameObject;
        //    child.SetActive(false);
        //}
        //im deactivating all buttons except specific nuttons
        //
        //buttonParent.transform.childCount < 3 is getting all the children not the active ones
        //IT MIGHT WOEK BETTER IF THE BUTTONS WERE INSTANTIATED RATHER THAN JUST ACTIVE
        if (one >= 1 && activeButtonCount < 6)
        {
            //I NEED TO SUBTRACT ONE BUT I ALSO NEED TO FIGURE OUT HOW TO KEEP THE NUMBER SO IF I DONT CHOOSE THE BUTTON IT WILL ADD THEM BACK
            Debug.Log("BUTTON 1");//activate button
            buttonOne.SetActive(true);
            //one--;//this is to make sure it decreases so when it runs again it won't show up.
            //THIS PROBLEM WITH THIS IS WITHOUT SUBRACTING THE  VAR IT WILL KEEP RUNNING SCORE AND RENDER ONE UNTIL ACTIVE BUTTON COUNTIS FALSE
            score++;//i want to increase the score. but i dont think this is necesarry/ this is so i dont get a game over right now
            activeButtonCount++;
            //one -= 1;//this should be on the button
            //Score();//call the same function
            //return;//return out so you dont run the rest.. I HAD THIS RETURN SO IT DIDNT RUN THE GAME OVER FUNCTION or the ROUND OVER UNTIL EVRYTHING WAS DONE
        }
        if (two >= 1 && activeButtonCount < 3)
        {
            Debug.Log("BUTTON 2");
            buttonTwo.SetActive(true);
            //two--;
            score++;
            activeButtonCount++;
            //Score();//call the same function
            //return;//return out so you dont run the rest
        }
        if (three >= 1 && activeButtonCount < 3)
        {
            Debug.Log("BUTTON 3");
            buttonThree.SetActive(true);
            //three--;
            score++;
            activeButtonCount++;
            //Score();//call the same function
            //return;//return out so you dont run the rest
        }
        if (four >= 1 && activeButtonCount < 3)
        {
            Debug.Log("BUTTON 4");
            buttonFour.SetActive(true);
            //four--;
            score++;
            activeButtonCount++;
            //Score();//call the same function
            //return;//return out so you dont run the rest
        }
        if (five >= 1 && activeButtonCount < 3)
        {
            Debug.Log("BUTTON 5");
            buttonFive.SetActive(true);
            //five--;
            score++;
            activeButtonCount++;
            //Score();//call the same function
            //return;//return out so you dont run the rest
        }
        if (six >= 1 && activeButtonCount < 3)
        {
            Debug.Log("BUTTON 6");
            buttonSix.SetActive(true);
            //six--;
            score++;
            activeButtonCount++;
            //Score();//call the same function
            //return;//return out so you dont run the rest
        }

        if (score > 0 && activeButtonCount == 0) { 
        //if score is greater than 0 do this 
        Debug.Log("YOURE SCORE THIS ROUND IS " + score);
        totalScore += score;
        Debug.Log("YOURE TOTAL SCORE IS" + totalScore);
        //ScoreReset();
        }
        else if(score <= 0 && activeButtonCount == 0)
        {
            Debug.Log("GAME OVER");
            //be sure to make sure to make a function that will skip the player if he is out
            //also be sure that if player selects a die that will not generate point that is re awakens the die
            displayPlayerChanger.NextPlayer();
            score = 0;
            totalScore = 0;


        }
        
    }

    //i dont think i need this. I might but i think
    //i might just make the numbers public
    public void TakeAwayDice(int dieNumber)
    {
        switch (dieNumber)
        {
            case 6:
                six -= 1;
                break;
            case 5:
                five -= 1;
                break;
            case 4:
                four -= 1;
                break;
            case 3:
                three -= 1;
                break;
            case 2:
                two -= 1;
                break;
            case 1:
                one -= 1;
                break;
            default:
                Debug.Log("Danger");
                break;
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
//3 scores
//each round you have a score for that roll
//each game you have a seperate total score for that round where you are perpetually rolling
//each game you have a overall score

//I need a player object that rolls the dice that stores the ammount of dice for each round.