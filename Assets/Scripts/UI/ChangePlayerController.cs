using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//was display
public class ChangePlayerController : MonoBehaviour
{

    public AudioManager audioManager;
    [Header("Dice and point reset")]
    public GameObject buttonAndDicePrefab;
    public GameObject diceParent;
    public int currentPlayerNum;

    public Text currentName;
    public Text currentScore;
    public Text potentialPoints;

    public int PointsToCarryOver
    {
        get
        {
            return pointsToCarryOver;
        }
    }

    private int pointsToCarryOver = 0;

    [Header("Dice and point reset")]
    public TotalDiceHandler totalDiceHandler;

    //Settings For Player
    public static RollSetting currentPlayerRollSettings;
    public PlayerData GetCurrentPlayer
    {
        get
        {
            return GameManager.data.players[currentPlayerNum];
        }
    }

    [Header("Final Round")]
    public GameObject endGamePanelPrefab;
    private int playerCountDown;
    private bool lastRound = false;
    public bool LastRound
    {
        get
        {
            return lastRound;
        }
        set
        {
            lastRound = value;
        }
    }
    private int finalScoreCheck;
    public int FinalScoreCheck
    {
        get { return finalScoreCheck; }
        set { finalScoreCheck = value; }
    }

    void Start()
    {
        currentPlayerNum = 0;
        DisplayPlayer();
        playerCountDown = GameManager.data.players.Count;
    }
    // void Update(){
    //     Debug.Log(CurrentGame.data.players[currentPlayerNum].rollSetting);//this part works
    // }
    public void DisplayPlayer()
    {
        DisplayScore();
        PlayerData currentPlayer = GameManager.data.players[currentPlayerNum];
        currentName.text = currentPlayer.playerName;
        currentPlayerRollSettings = currentPlayer.rollSetting;

    }
    public void NextPlayer()
    {
        audioManager.Play("Next Turn");
        pointsToCarryOver = 0;
        if (currentPlayerNum < GameManager.data.players.Count - 1) { currentPlayerNum++; }
        else { currentPlayerNum = 0; }
        DisplayPlayer();
        ReactivateDice();
        PotentialPointsUIUpdate();//this is hiding the UI after you switch players
        if (lastRound) GameFinished();
    }
    public void PreviousPlayer()
    {
        
        //if need to check if they are still in play or not
        //maybe make a function that decreases until they find a player that is still in play
        if (currentPlayerNum > 0) { currentPlayerNum -= 1; }
        else { currentPlayerNum = GameManager.data.players.Count - 1; }
        DisplayPlayer();
    }

    public void DisplayScore()
    {
        PlayerData currentPlayer = GameManager.data.players[currentPlayerNum];
        currentScore.text = "Score: " + currentPlayer.totalScore.ToString();
        finalScoreCheck = currentPlayer.totalScore;
    }


    
    public void ReactivateDice()
    {
        Destroy(diceParent.transform.GetChild(0).gameObject);
        //GameObject currentDiceGroup = Instantiate(buttonAndDicePrefab, transform.position, Quaternion.identity, diceParent.transform);
        GameObject currentDiceGroup = Instantiate(buttonAndDicePrefab, diceParent.transform);

        Debug.Log("NEW Dice Group:"+ currentDiceGroup.transform.position);
        Debug.Log("NEW Dice Group:" + currentDiceGroup.transform.localPosition);
    }

    public void RolledNewScore(int newPoints)
    {
        newPoints += pointsToCarryOver;
        PlayerData currentPlayer = GameManager.data.players[currentPlayerNum];
        currentPlayer.totalScore += newPoints;
        currentPlayer.roundScore.Add(newPoints);
        
    }

    public void CarryScoreForNewDice(int carryOver)
    {
        pointsToCarryOver += carryOver;
   
        //PotentialPointsUIUpdate(newPoints);
    }
    
    public void PotentialPointsUIUpdate(int potentialIncomingPoints = 0)
    {
        //i think this runs everytime a score is passed through. the default is 0. so when the player switches it resets to 0. every time you score you pass it points
        Debug.Log("Potential running");
        //everytime theres a new dice potential points is 0...
        //if threre are now carry over points or current points display nothing
        //otherwise show potential points plus carry over points
        //everytime you switch players reset pointToCarryOver
        if (potentialIncomingPoints == 0 && pointsToCarryOver == 0) { potentialPoints.text = ""; }
                
        else { potentialPoints.text = (potentialIncomingPoints+= pointsToCarryOver).ToString(); }
    }

    public void FarkledCounter(int didFarkle)
    {
        //if you pass in 1 which is yes he farkled increase farkle count
        //otherwise pass in 0 he didnt
        if(didFarkle > 0)
        {
            GameManager.data.players[currentPlayerNum].farkleCount++;
            if(GameManager.data.players[currentPlayerNum].farkleCount >= 3)
            {
                Debug.Log("player farkled");
                GameManager.data.players[currentPlayerNum].farkleCount = 0;
                RolledNewScore(-1000);
                
            }
            else {
                Debug.Log("Thin ice");
                RolledNewScore(0);
            }
        }
        else { GameManager.data.players[currentPlayerNum].farkleCount = 0; }//they rolled something pointworthy
    }

    private int GetPlayerScore()
    {
        PlayerData currentPlayer = GameManager.data.players[currentPlayerNum];
        //return currentPlayer.totalScore;
        return 11;
    }


    private void GameFinished()
    {
        playerCountDown--;


        if (playerCountDown <= 0)
        {
            Debug.Log("GAME IS FINISHED");
            GameObject player = Instantiate(endGamePanelPrefab, transform.position, Quaternion.identity, this.gameObject.transform);
            player.SetActive(true);
            //SceneManager.LoadScene("GameFinished");
            //maybe I should add last gameobject that shows game results

        }
    }
}
