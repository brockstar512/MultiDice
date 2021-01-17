using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//was nameTransfer
public class CurrentGame : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject namePrompt;
    public InputField textOfInput;

    public PlayerData player;

    public List<PlayerData> totalPlayers;

    [SerializeField] public static GameData data;



    void Awake()
    {
        //create a game 
        data = new GameData();
        //start_time = System.DateTime.Now;
        //Debug.Log(data.start_time);
    }


    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        //Debug.Log("HERE IS NAME" + theName);
        player = new PlayerData();
        player.playerName = theName;
        data.players.Add(player);
        textOfInput.text = "";
    }
}

