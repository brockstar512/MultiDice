using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject namePrompt;
    public InputField textOfInput;
    


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
        Debug.Log(data.start_time);
    }
    void Update()
    {

    }

    public void StoreName()
    {
        //i might need to just referesh the poptmp 
        //**** MAYBE I NEED TO GRAB THE CURRENT NAMESPACES NAME
        //I need to grab this insantiated gameObject.. right now its grabbing the inactive one
        theName = inputField.GetComponent<Text>().text; //this was grabbing the clone
        
        //theName = inputField.GetComponent<Text>().text;
        //theName = inputFieldParent.transform.GetChild(inputFieldParent.transform.childCount-1).gameObject.transform.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>().text = "Welcome " + theName;
        Debug.Log("HERE IS NAME"+theName);
        player = new PlayerData();
        //theName = "MARK";
        player.playerName = theName;
        data.players.Add(player);
        //Destroy(promptListParent.transform.GetChild(2));
        //Debug.Log("Here is the players count" + data.players.Count);//works
        // Debug.Log("Here is the players name" + data.players[0].playerName);
        textOfInput.text = "";
        //inputField.Clear();

    }
    

   
}
