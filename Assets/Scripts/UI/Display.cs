using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



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
}
