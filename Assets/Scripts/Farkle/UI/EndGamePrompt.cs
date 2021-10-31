using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class EndGamePrompt : MonoBehaviour
{

    public GameObject bet;
    public GameObject playerList;

void Awake()
    {
        bet.GetComponent<Text>().text = "Bet: " + GameManager.data.bet;
        //CurrentGame.data.players[currentPlayerNum]

        //List<PlayerData> sortedPlayers = CurrentGame.data.players.OrderByDescending(player => player.totalScore).ToList();
        GameManager.data.players = GameManager.data.players.OrderByDescending(player => player.totalScore).ToList();
        GameData completeGame = new GameData(GameManager.data);
        //test to see if copy works

        PopulatePlayerList();
    }

    private void PopulatePlayerList()
    {
         
        for(int i = 0; i < GameManager.data.players.Count; i++)
        {
            GameObject player = Instantiate(playerList.transform.GetChild(0).gameObject, transform.position, Quaternion.identity, playerList.transform);
            var currentPlayer = GameManager.data.players[i];
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
