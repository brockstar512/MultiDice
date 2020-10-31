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
    [SerializeField] public static GameData data;

    //number form prompt
    //public GameObject playerNumberText;

    //this is to delete the prompts as you go
    public GameObject promptListParent;

    void Awake()
    {
        //create a game 
        data = new GameData();
        //start_time = System.DateTime.Now;
        data.players = new List<PlayerData>();
        Debug.Log(data.start_time);
    }
    void Update()
    {

    }

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>().text = "Welcome " + theName;
        //create the new player data within data
        //data.players = new List<PlayerData>();
        //create the new player data on its own
        Debug.Log(theName);//name is nothing
        theName = "MARK";
        player = new PlayerData();
        player.playerName = theName;
        data.players.Add(player);
        //data.players.Add();
        //data.players.playerName = theName;
        //data.players.Add(player);
        //Destroy(promptListParent.transform.GetChild(2));
        Debug.Log("Here is the players count" + data.players.Count);
        Debug.Log("Here is the players name" + data.players[0].playerName);
    }
    

    public void StorageNameController(PlayerData[] player)
    {
        //i can add the player data to an array to add to the game data or I can manually add it to the game data

    }
    //public void ConfirmationNameList(GameData data)
    //{

    //}
}
//delete other children