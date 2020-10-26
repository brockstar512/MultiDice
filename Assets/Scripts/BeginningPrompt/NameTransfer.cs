using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject namePrompt;


    public PlayerData player;
    //public PlayerData[] playersArray;

    //public string[] playersArray;
    public List<PlayerData> totalPlayers;

    //public GameData data;
    [SerializeField] public GameData data;

    void Awake()
    {
        //create a game 
        data = new GameData();
    }
    void Update()
    {
        Debug.Log(data.players.Count);
    }

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>().text = "Welcome " + theName;

        player = new PlayerData();
        player.playerName = theName;
        data.players.Add(player);
        //Destroy(namePrompt);
    }
    

    public void StorageNameController(PlayerData[] player)
    {
        //i can add the player data to an array to add to the game data or I can manually add it to the game data

    }

}
//delete other children