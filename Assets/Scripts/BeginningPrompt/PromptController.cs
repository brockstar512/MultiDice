using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour
{


    public AudioManager audioManager;


    void Awake()
    {
        //count = 1;
        int trackNumber = Random.Range(0,4);
        audioManager.PlayMusic(trackNumber);
    }
    
}

