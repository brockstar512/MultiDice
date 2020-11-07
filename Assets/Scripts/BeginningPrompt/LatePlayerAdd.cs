using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatePlayerAdd : MonoBehaviour
{
    public PromptController promptController;
    public GameObject completeList;


    public void AddLatePlayer()
    {
        promptController.ReserectPrompt(1);
        completeList.SetActive(false);
        //Destroy(completeList);//destroy object completely destorys this stuff.

    }
}
