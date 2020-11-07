﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationList : MonoBehaviour
{
    public GameObject playerListItemConfirmed;
    public GameObject holder;



    private void RenderPlayerList()
    {
        foreach (PlayerData playeritem in NameTransfer.data.players)
        {
            GameObject Player = Instantiate(playerListItemConfirmed) as GameObject;
            Player.SetActive(true);
            Player.transform.SetParent(holder.transform, false);
            Player.transform.localRotation = Quaternion.identity;
            Player.transform.GetComponent<Text>().text = playeritem.playerName;
        }
    }


    public void ReRender()
    {
        DeleteList();
        RenderPlayerList();
    }

    private void DeleteList()
    {
      
        for(int i = 1; i < holder.transform.childCount; i++){
            Destroy(holder.transform.GetChild(i).gameObject);
        }
    }

}
