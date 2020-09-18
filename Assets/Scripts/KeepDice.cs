using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDice : MonoBehaviour
{
    [SerializeField] public bool saveDice = false;
    [SerializeField] private bool selectionConfirmed = false;
    


    public void ClickMe()
    {
        //var only has block scope
        var outlineSelected = GetComponent<Outline>();
        saveDice = !saveDice;
        selectionConfirmed = saveDice;

        if(selectionConfirmed){
            outlineSelected.OutlineWidth = 20;
        }
        else{
            outlineSelected.OutlineWidth = 0;
        }
    }
}
