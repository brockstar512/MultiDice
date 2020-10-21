using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    //static bool that checkif if any of the dice switch it on
    public static bool somethingIsSelected = false;

    [SerializeField] GameObject scoreButton;
    [SerializeField] GameObject endRoundButton;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (somethingIsSelected)
        {
            //Debug.Log("ON");
            scoreButton.SetActive(true);
            endRoundButton.SetActive(false);
        }
        else
        {
            //Debug.Log("OFF");
            endRoundButton.SetActive(true);
            scoreButton.SetActive(false);
        }
    }
}
