using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public static bool somethingIsSelected = false;

    [SerializeField] GameObject scoreButton;
    [SerializeField] GameObject endRoundButton;

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
