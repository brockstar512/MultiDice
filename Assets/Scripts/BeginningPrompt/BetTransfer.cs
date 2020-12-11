using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetTransfer : MonoBehaviour
{
    public string theBet;
    public GameObject inputField;


    public GameObject beginningPrompts;
    public GameObject completeList;

    public GameObject theGame;

    public void storeBet()
    {
        theBet = inputField.GetComponent<Text>().text;
        CurrentGame.data.bet = theBet;

        //activate the game and destroy everything else
        //Debug.Log(CurrentGame.data.bet);

        this.gameObject.SetActive(false);
        theGame.SetActive(true);


        Destroy(beginningPrompts);
        Destroy(completeList);
    }


}
