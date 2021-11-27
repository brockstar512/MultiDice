using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSelectionManager : MonoBehaviour
{

    public GameObject diceButtonParent;



    //prives the roller number to the toggles images
    public void ProvideDiceAsOption(int diceRoll)
    {
        //Debug.Log("Handing off dice value");
        diceButtonParent.GetComponent<SelectDice>().ActivateAvailableDice(diceRoll);
    }

    //function that deletes a certain amount

    //a function that creates a certain amount of dice

    //

}
