using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class GameData
{
    public List<PlayerData> players;
    public int roundTotal;
    public int numberOfPlayers => players.Count;

    public string bet;
    public System.DateTime start_time;
    public string url;



    public GameData()
    {
        //each game creates new game data , each player input creates new player data
        PlayerData player = new PlayerData();
        player.playerName = "Player 1";

        // Debug.Log("INCOMING NAME : "+newPlayer);

        players = new List<PlayerData>();
        player.rollSetting = LoadItems.data.mRollSetting;//data.mRollSetting
        players.Add(player);
        start_time = System.DateTime.Now;

    }

    public GameData(GameData copy)
    {
        this.players = new List<PlayerData>(copy.players);
        this.start_time = copy.start_time;
    }

    //    public void AddPlayer(string playerName, RollSetting rollSetting)

    public void AddPlayer(string playerName)
    {
        string newPlayer = playerName.Length == 1 ? "Player " + (this.players.Count).ToString() : playerName;

        // Debug.Log("INCOMING NAME : "+newPlayer);


        //the previous player data should get the name being past in 
        this.players[this.players.Count - 1].playerName = newPlayer;//player 1 = marshall

        //create a new player named the count of player totals
        PlayerData player = new PlayerData("Player " + (this.players.Count + 1).ToString());// player 2 = player 2

        //give the player the default roll setting
        player.rollSetting = LoadItems.data.mRollSetting;//data.mRollSetting
        Debug.Log("Player roll setting:"+ player.rollSetting);

        //add it to the list
        this.players.Add(player); //2nd item in the list = player 2
    }

    public void DeletePlayer(int index)
    {
        if (index == 0)
            return;
        this.players.RemoveAt(index);
        //this.players.RemoveRange(index-1,2);

    }

}
public class PlayerData
{
    public string playerName;
    public bool isInPlay;
    public List<int> roundScore;
    public int totalScore;
    public int farkleCount;
    public RollSetting rollSetting;

    //this is called a constructor it gives the class pre defined values
    //if you make the constructor have variables in the () you have to pass them in aas arguments when you create an instance of it
    public PlayerData(string name = "")
    {
        playerName = name;
        isInPlay = true;
        totalScore = 0;
        roundScore = new List<int>();
        farkleCount = 0;
    }

}








//celevrating your past achievements
//https://www.youtube.com/watch?v=dk5WuADwlDU
//interesting conversation with tegan
//and what informs your performance is perspective.


