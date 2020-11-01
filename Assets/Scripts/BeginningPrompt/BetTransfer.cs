﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetTransfer : MonoBehaviour
{
    //this should reference not the main input field but the text under the input field in the heirchy
    public string theBet;
    public GameObject inputField;

    
    public GameObject theGame;

    public void storeBet()
    {
        theBet = inputField.GetComponent<Text>().text;
        NameTransfer.data.bet = theBet;

        //activate the game and destroy everything else
        Debug.Log(NameTransfer.data.bet);

        this.gameObject.SetActive(false);
        theGame.SetActive(true);
    }


}
