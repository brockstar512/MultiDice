using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour
{
    public GameObject playerCount;//this ended up doing nothing
    public int count;
    public Text ActiveNumber;
    public GameObject numberPrompt;
    [SerializeField] playerController playerController;
    //accumulate an array of players to give to player controller to make them officali players

    public GameObject namePrompt;
    public GameObject playerList;


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
        ////
        ////--------
        //if (promptExists)
        //{
        //    Destroy(newPlayer);//this chunk needs to be refactor
        //}
        //promptExists = false;
        ////--------
        ////
		/////make a function thats tied to that button that also deletes the second or 1st child of the list.


        GameObject newPlayer = Instantiate(namePrompt) as GameObject;
        newPlayer.SetActive(true);
        newPlayer.transform.SetParent(playerList.transform, false);
        newPlayer.transform.localRotation = Quaternion.identity;
        promptExists = true;

        count--;//i do if I can figure out. give count to gamedata or I can just do .count();

    }

    public void MoreInputs()
    {
        //put name in array. either here or in name transfor
        //delete the first child **
        if (count > 0)
        {
            
            PlayerInputCount(count);
        }
    }


}
//i had a hard time figureing out the Text.text and how to grab text and over write text
//i think if I was grabbing stopping at the text component id say Text blah blah blah getCOmponent<Text>()
//but if i was say .text it would be string
