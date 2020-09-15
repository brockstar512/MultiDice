using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalDiceHandler : MonoBehaviour
{

    public Dice[] totalDice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Dice die in totalDice)
        {
            Debug.Log(die.stay + " if true, you want to keep "+ die.diceValue);
        }

        
    }
}
