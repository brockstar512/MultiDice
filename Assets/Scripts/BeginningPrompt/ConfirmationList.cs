using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationList : MonoBehaviour
{
    public GameObject confirmationListParent;
    public GameObject playerListItemConfirmed;


    void Awake()
    {
        //Debug.Log("Here is the players count" + data.players.Count);
        //Debug.Log("Here is the players count" + NameTransfer.data.players[0].playerName);
        foreach (PlayerData playeritem in NameTransfer.data.players)
        {
            Debug.Log("NAME: " + playeritem.playerName);
            GameObject Player = Instantiate(playerListItemConfirmed) as GameObject;
            Player.SetActive(true);
            Player.transform.SetParent(confirmationListParent.transform, false);
            Player.transform.localRotation = Quaternion.identity;
            Player.transform.GetComponent<Text>().text = playeritem.playerName;
        }
    }

    //public void ConfirmationList(GameData data)
    //{
    //    Debug.Log("Here is the players count" + data.players.Count);
    //}

}
//i might need to either passit in through a script that is still alive at this time or ...
//make a back end so its serialized and pull it in
//playerController
//or give it to player controller and pull from it