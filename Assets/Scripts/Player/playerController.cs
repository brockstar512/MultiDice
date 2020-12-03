using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameData data;
    public PlayerData player;

    private int currentNum = 0;

    //is this running at all?*****
  //if player is not in play run this again
    public int PlayerCountController()
    {
        int newPlayerNumber;
        int playerCount = NameTransfer.data.numberOfPlayers;
        if(currentNum >= playerCount)
        {
            newPlayerNumber = 0;
        }
        else
        {
            newPlayerNumber = currentNum + 1;
        }
        //if player is not in maybe run again
        return newPlayerNumber;
    }


     


}







//what if at first it asks you how many players there are
//then is takes that number and iterates an input field that many times
//creating a player each time you subtmit an input feild
//if its the bet version it will say whats the bet
//