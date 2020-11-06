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
        RenderPlayerList();
    }

//when i add a new player I want to delete all of what is instantiate and rerender list
//delete all the children then do it again

    private void RenderPlayerList()
    {

        //RenderPlayerList(//player list)
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
    //remove player list

    public void ReRender()
    {
        //delete list
        //rerender list
    }

    private void DeleteList()
    {
        //iterate each child and destroy
        //for(int i = 0; i <child count; i++;){
        //delete the child I i
        //}
    }

}
//i might need to either passit in through a script that is still alive at this time or ...
//make a back end so its serialized and pull it in
//playerController
//or give it to player controller and pull from it