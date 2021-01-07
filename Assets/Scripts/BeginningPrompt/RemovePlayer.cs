using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemovePlayer : MonoBehaviour
{
    public ConfirmationList confirmationList;
    private bool isOn = true;
    public void RemovePlayerButton()
    {
        int index = this.gameObject.transform.GetSiblingIndex() - 1;
        CurrentGame.data.players.RemoveAt(index);
        confirmationList.ReRender();

    }

    public void ShowRemoveButtons()
    {
        for(int i = 1; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).transform.gameObject.SetActive(isOn);
        }
        isOn = !isOn;
    }

    //i dont think that is that big of a deal if it doesn't have are you sure for remove player?
    //public void AreYouSure()
    //{

    //}
}
