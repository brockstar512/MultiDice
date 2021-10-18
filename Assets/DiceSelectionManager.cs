using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSelectionManager : MonoBehaviour
{

    public GameObject diceButtonParent;
    public GameObject diceObjectParent;




    public void ProvideDiceAsOption(int diceRoll)
    {
        //Debug.Log("Handing off dice value");
        diceButtonParent.GetComponent<SelectDice>().ActivateAvailableDice(diceRoll);
    }
}
