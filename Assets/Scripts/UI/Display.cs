﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//this should probably be renamed
public class Display : MonoBehaviour
{
    public int currentPlayerNum;
    //public float scoreRound;
    //public float totalScore;
    //public float newRollScore;
    public Text currentName;
    public Text currentScore;


    //public string playerName;
    // Start is called before the first frame update

    public Dice[] totalDice;

    void Start()
    {
        currentPlayerNum = 0;
        DisplayPlayer();
    }

    public void DisplayPlayer()
    {
        Debug.Log(currentPlayerNum);
        Debug.Log("DISPLAY PLAYER");
        PlayerData currentPlayer = NameTransfer.data.players[currentPlayerNum];
        currentName.text = currentPlayer.playerName;
        Debug.Log(currentPlayer.playerName);
        ReactivateDice();
    }

    public void NextPlayer()
    {
        Debug.Log("NEXT PLAYER");
        if (currentPlayerNum < NameTransfer.data.players.Count-1) {currentPlayerNum ++;}
        else {currentPlayerNum = 0;}
        DisplayPlayer();
    }
    public void PreviousPlayer()
    {


        Debug.Log("PREVIOUS PLAYER");
        //if need to check if they are still in play or not
        //maybe make a function that decreases until they find a player that is still in play
        if (currentPlayerNum > 0) { currentPlayerNum -= 1; }
        else { currentPlayerNum = NameTransfer.data.players.Count - 1; }
        DisplayPlayer();
    }

    public void ReactivateDice()
    {
        //i could use the reset in die
        foreach (Dice die in totalDice)
        {
            //this.gameObject.parent.gameObject.SetActive(true);//this thinks its referening to display
            //reset the location too
            //die.stay = false;
            //die.diceValue = 0;
            //die.transform.parent.gameObject.SetActive(true);
            //die.gameObject.SetActive(true);
            die.ResetForNewPlayer();
        }
    }
}