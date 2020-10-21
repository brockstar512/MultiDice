using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//this is going to have game data that has a list of the players
//and keeps track of the round number *could change this. round total
//and what the bet is
public class GameData
{
    public List<PlayerController> playersData;
    public int roundTotal;
    public int numberOfPlayers;
    public string bet;
    //could also include start date
    public System.DateTime start_time;


    public class PlayerController
    {
        //player has all information about the player - round data
        //there should be a game controller that has all information for each player - workout data
        public string playerName;
        public bool isInPlay;
        
        //this is going to be the list of the score for each round
        //then after its that persons round is over it goes into their total score
        public List<int> roundScore;
        public int totalScore;

    }


    public GameData()
    {
        //each game creates new game data , each player input creates new player data
        playersData = new List<PlayerController>();
        //numberOfPlayers = playersData.Count();
        //I ONLY NEED PLAYER COUNT TO MAKE SURE THEY DON"T EXEED PLAYER LIMIT
        start_time = System.DateTime.Now;

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