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


    public GameObject confirmationPanel;



    public bool promptExists= false;

    void Awake()
    {
        count = 1;
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

  //the button in the number prompt calls this function and passes it a number
    public void PlayerInputCount(int playerCount)
    {


        GameObject newPlayer = Instantiate(namePrompt) as GameObject;
        newPlayer.SetActive(true);
        newPlayer.transform.SetParent(playerList.transform, false);
        newPlayer.transform.localRotation = Quaternion.identity;
        promptExists = true;
        newPlayer.transform.GetChild(1).gameObject.transform.GetComponent<Text>().text = playerNumber.ToString();
        playerNumber++;

        count--;        
    }

    public void MoreInputs()
    {
        //put name in array. either here or in name transfor
        //delete the first child **
        if (count > 0)
        {
            //this controls making more prompts.
            PlayerInputCount(count);
        }
        else if(count <= 0)
        {
            //Debug.Log("game is ready");
            //set another button up that increases count + 1
            //activate the last prompt that says here are the players
            confirmationPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }


}
//i had a hard time figureing out the Text.text and how to grab text and over write text
//i think if I was grabbing stopping at the text component id say Text blah blah blah getCOmponent<Text>()
//but if i was say .text it would be string
