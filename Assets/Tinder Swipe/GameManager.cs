using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private PlayerData player;
    public List<PlayerData> totalPlayers;
    public static GameData data;

    public void Awake()
    {
        data = new GameData();
    }

    //i should be able to delete names input intirly
    

 
}
