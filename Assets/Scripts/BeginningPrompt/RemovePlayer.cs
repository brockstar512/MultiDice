using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemovePlayer : MonoBehaviour
{
    public ConfirmationList confirmationList;
    public void RemovePlayerButton()
    {
        int index = this.gameObject.transform.GetSiblingIndex() - 1;
        Debug.Log(index);
        //
        //confirmationList.ReRender();
    }

    //i dont think that is that big of a deal if it doesn't have are you sure for remove player?
    //public void AreYouSure()
    //{

    //}
}
