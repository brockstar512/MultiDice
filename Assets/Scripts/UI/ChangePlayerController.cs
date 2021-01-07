using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//was display
public class ChangePlayerController : MonoBehaviour
{
    [Header("Dice and point reset")]
    public GameObject buttonAndDicePrefab;
    public GameObject diceParent;
    public int currentPlayerNum;

    public Text currentName;
    public Text currentScore;
    public Text potentialPoints;

    [Header("Dice and point reset")]
    public TotalDiceHandler totalDiceHandler;

    void Start()
    {
        currentPlayerNum = 0;
        DisplayPlayer();
    }


    public void DisplayPlayer()
    {
        DisplayScore();
        PlayerData currentPlayer = CurrentGame.data.players[currentPlayerNum];
        currentName.text = currentPlayer.playerName;
    }
    //if next player is not in recursively call this
    public void NextPlayer()
    {
        if (currentPlayerNum < CurrentGame.data.players.Count - 1) { currentPlayerNum++; }
        else { currentPlayerNum = 0; }
        DisplayPlayer();
        ReactivateDice();
        PotentialPointsUIUpdate();//this is hiding the UI after you switch players
    }
    public void PreviousPlayer()
    {
        
        //if need to check if they are still in play or not
        //maybe make a function that decreases until they find a player that is still in play
        if (currentPlayerNum > 0) { currentPlayerNum -= 1; }
        else { currentPlayerNum = CurrentGame.data.players.Count - 1; }
        DisplayPlayer();
    }

    public void DisplayScore()
    {
        PlayerData currentPlayer = CurrentGame.data.players[currentPlayerNum];
        currentScore.text = "Score: " + currentPlayer.totalScore.ToString();
    }


    
    public void ReactivateDice()
    {
        Destroy(diceParent.transform.GetChild(0).gameObject);
        GameObject currentDiceGroup = Instantiate(buttonAndDicePrefab, transform.position, Quaternion.identity, diceParent.transform) as GameObject;
    }

    public void RolledNewScore(int newPoints)
    {
        PlayerData currentPlayer = CurrentGame.data.players[currentPlayerNum];
        currentPlayer.totalScore += newPoints;
        currentPlayer.roundScore.Add(newPoints);
        
    }

    public void PotentialPointsUIUpdate(int potentialIncomingPoints = 0)
    {
        if (potentialIncomingPoints == 0) { potentialPoints.text = ""; }
        else { potentialPoints.text = potentialIncomingPoints.ToString(); }
    }

    public void FarkledCounter(int didFarkle)
    {
        //if you pass in 1 which is yes he farkled increase farkle count
        //otherwise pass in 0 he didnt
        if(didFarkle > 0)
        {
            CurrentGame.data.players[currentPlayerNum].farkleCount++;
            if(CurrentGame.data.players[currentPlayerNum].farkleCount >= 3)
            {
                Debug.Log("player farkled");
                CurrentGame.data.players[currentPlayerNum].farkleCount = 0;
                RolledNewScore(-1000);
                
            }
            else {
                Debug.Log("Thin ice");
                RolledNewScore(0);
            }
        }
        else { CurrentGame.data.players[currentPlayerNum].farkleCount = 0; }//they rolled something pointworthy
    }
}
