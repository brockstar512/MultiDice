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
        Destroy(numberPrompt);
    }


}
//i had a hard time figureing out the Text.text and how to grab text and over write text
//i think if I was grabbing stopping at the text component id say Text blah blah blah getCOmponent<Text>()
//but if i was say .text it would be string
