using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour
{
    public GameObject playerCount;//this ended up doing nothing
    public int count;
    public int playerNumber=1;
    public Text ActiveNumber;
    public GameObject numberPrompt;
    [SerializeField] playerController playerController;
    

    public GameObject namePrompt;
    public GameObject playerList;

    public AudioManager audioManager;
    public GameObject confirmationPanel;

    public string mostRecentName;

    public bool promptExists= false;

    public ConfirmationList confirmationList;

    void Awake()
    {
        count = 1;
        int trackNumber = Random.Range(0,4);
        audioManager.PlayMusic(trackNumber);
    }


    public void AddPlayer()
    {
        if(count <= 9)
        {
            count++;
            UpdateAmount();
        }

    }

    public void SubtractPlayer()
    {
        if (count > 1)
        {
            count--;
            UpdateAmount();
        }
    }


    public void UpdateAmount()
    {
        ActiveNumber.text = count.ToString();
    }


    public void ConfirmAmountOfPlayers()
    {
        //send count to a sister script that will instantiate an input field that creates the name input
        //there those will create the players.
        //when this runs. this shoudl create the game json
        //it should also destroy all the # prompts

        PlayerInputCount(count);
        Destroy(numberPrompt);
    }

    public void ReserectPrompt(int additionalCount)
    {
        count = 1;

        this.gameObject.SetActive(true);
        MoreInputs();
        //try to rerender list from here
        //confirmationList.ReRender();
        //Debug.Log("PROMPT CONTROLLER NameTransfer.data.players" + NameTransfer.data.players.Count);
    }

    //the button in the number prompt calls this function and passes it a number
    public void PlayerInputCount(int playerCount)
    {

        namePrompt.SetActive(true);
        promptExists = true;
        namePrompt.transform.GetChild(1).gameObject.transform.GetComponent<Text>().text = playerNumber.ToString();
        playerNumber++;

        count--;        
    }

    public void MoreInputs()
    {

        if (count > 0)
        {
            PlayerInputCount(count);
        }
        else if(count <= 0)
        {
            //if this is already active .... confirmationPanel.SetActive(true)

            //Debug.Log("game is ready");
            //set another button up that increases count + 1
            //activate the last prompt that says here are the players
            //confirmationList.ReRender();
            confirmationList.ReRender();
            confirmationPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    ///add name button calls more inputs and it runs store name
}
//i had a hard time figureing out the Text.text and how to grab text and over write text
//i think if I was grabbing stopping at the text component id say Text blah blah blah getCOmponent<Text>()
//but if i was say .text it would be string
