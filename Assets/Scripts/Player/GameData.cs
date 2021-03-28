using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GameData
{
    public List<PlayerData> players;
    public int roundTotal;
    public int numberOfPlayers;
    public string bet;
    public System.DateTime start_time;

    
    public GameData()
    {
        //each game creates new game data , each player input creates new player data
        players = new List<PlayerData>();
        start_time = System.DateTime.Now;

    }

    public GameData(GameData copy)
    {
        this.players = new List<PlayerData>(copy.players);
        this.start_time = copy.start_time;
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
    public PlayerData()
    {
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




//          class.variable calls what this variable returns 
//
//public float totalMoveAccuracy
//{
//    get
//    {
//        float sum = 0;
//        float count = 0;

//        foreach (RoundData round in rounds)
//        {
//            if (round.type != RoundType.Sparring)
//            {
//                sum += round.moveAccuracy;
//                count++;
//            }
//        }
//        if (count != 0)
//        {
//            return sum / count;
//        }
//        else
//        {
//            return -1;
//        }
//    }
//}