using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//was display
public class ChangePlayerController : MonoBehaviour
{
    [Header("Dice and point reset")]
    public int currentPlayerNum;
    //public float scoreRound;
    //public float totalScore;
    //public float newRollScore;
    public Text currentName;
    public Text currentScore;
    public Text potentialPoints;

    [Header("Dice and point reset")]
    public Dice[] totalDice;
    public TotalDiceHandler totalDiceHandler;

    void Start()
    {
        currentPlayerNum = 0;
        DisplayPlayer();
        //DisplayScore();
    }


    public void DisplayPlayer()
    {
        DisplayScore();
        //Debug.Log(currentPlayerNum);
        //Debug.Log("DISPLAY PLAYER");
        PlayerData currentPlayer = CurrentGame.data.players[currentPlayerNum];
        currentName.text = currentPlayer.playerName;
        //Debug.Log(currentPlayer.playerName);
        //ReactivateDice();

    }
    //if next player is not in recursively call this
    public void NextPlayer()
    {
        //Debug.Log("NEXT PLAYER");
        if (currentPlayerNum < CurrentGame.data.players.Count - 1) { currentPlayerNum++; }
        else { currentPlayerNum = 0; }
        DisplayPlayer();
        ReactivateDice();
        PotentialPointsUIUpdate();//this is hiding the UI after you switch players
    }
    public void PreviousPlayer()
    {
        //Debug.Log("PREVIOUS PLAYER");
        //if need to check if they are still in play or not
        //maybe make a function that decreases until they find a player that is still in play
        if (currentPlayerNum > 0) { currentPlayerNum -= 1; }
        else { currentPlayerNum = CurrentGame.data.players.Count - 1; }
        DisplayPlayer();
    }

    public void DisplayScore()
    {
        //Debug.Log("Display the new score");
        PlayerData currentPlayer = CurrentGame.data.players[currentPlayerNum];
        currentScore.text = "Score: " + currentPlayer.totalScore.ToString();
        //
        //** CHANGE DISPLAYS NAME AND CHANCE NAMETRANSFER NAME
        //I need to display score to make sure its properly being added. I should display total score
        //I should add total score but keep track of score per round so in history they can have a breakdown
        //PlayerData currentPlayer = NameTransfer.data.players[currentPlayerNum].totalScore;
    }


    //this is causing an error
    public void ReactivateDice()
    {
        //i could use the reset in die
        foreach (Dice die in totalDice)
        {
            //reset the location too
            die.ResetForNewPlayer();
        }
    }

    public void RolledNewScore(int newPoints)
    {
        PlayerData currentPlayer = CurrentGame.data.players[currentPlayerNum];
        //currentPlayer.roundScore.Add(newPoints);
        currentPlayer.totalScore += newPoints;
        currentPlayer.roundScore.Add(newPoints);
        
    }

    public void PotentialPointsUIUpdate(int potentialIncomingPoints = 0)
    {
        if (potentialIncomingPoints == 0) { potentialPoints.text = ""; }
        else { potentialPoints.text = potentialIncomingPoints.ToString(); }
    }
}
