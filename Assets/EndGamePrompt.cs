using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGamePrompt : MonoBehaviour
{

    public GameObject bet;
    public GameObject playerList;

void Awake()
    {
        bet.GetComponent<Text>().text = "Bet: " + CurrentGame.data.bet;
        //CurrentGame.data.players[currentPlayerNum]
        PopulatePlayerList();
    }

    private void PopulatePlayerList()
    {
         
        for(int i = 0; i < CurrentGame.data.players.Count; i++)
        {
            GameObject player = Instantiate(playerList.transform.GetChild(0).gameObject, transform.position, Quaternion.identity, playerList.transform);
            var currentPlayer = CurrentGame.data.players[i];
            player.transform.GetChild(0).GetComponent<Text>().text = currentPlayer.playerName;
            player.transform.GetChild(1).GetComponent<Text>().text = currentPlayer.totalScore.ToString();

            //currentPlayer.playerName;
            //currentPlayer.totalScore;
        }
    }

    public void MoveToRecordingScreen()
    {
        SceneManager.LoadScene("GameFinished");
    }
}
