using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transport : MonoBehaviour
{
    public ScreenPacket[] GameScreens;
    public ManagePacket details;

    public void GameDetails(string currentGame)
    {
        GameManager.GameType viewGame = (GameManager.GameType)System.Enum.Parse(typeof(GameManager.GameType), currentGame);

        GameManager.data.currentGame = viewGame;
        //game should slide in and by the enum we pass in the scriptable object should distribute the information

        //title
        //play
        //how to play
        //brief summary
        //back... which refreshes current game to none
        foreach(ScreenPacket packet in GameScreens)
        {
            if(packet.gameType == viewGame)
            {
                details.Distribute(packet);
                details.MoveIn();
                break;
            }

        }
        
    }


}
