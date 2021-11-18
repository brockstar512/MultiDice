using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiceCounter : MonoBehaviour, ISwipeable
{
    public int numberOfDice = 1;
    public TextMeshProUGUI textField;
    public Button moreButton;
    public Button lessButton;
    [SerializeField] GameObject diceParent;
    private int DestroyDice
    {
        get => 6-numberOfDice;
    }


    private void Awake()
    {
        HandleButtonChange();
    }

    public void More()
    {
        numberOfDice++;
        HandleButtonChange();
    }
    public void Less()
    {
        numberOfDice--;
        HandleButtonChange();

    }

    public void StartGame()
    {
        Debug.Log("INITIATE DICE: pass of the count to dice initializer here");
        for(int i =0;i < DestroyDice; i++)
        {
            Destroy(diceParent.transform.GetChild(i).gameObject);
        }
            

        Destroy(this.transform.gameObject);
    }

    void HandleButtonChange()
    {
        textField.text = numberOfDice.ToString();
        if (numberOfDice >= 10)
        {
            moreButton.interactable = false;

        }
        else if(numberOfDice <= 1)
        {
            lessButton.interactable = false;
        }
        else
        {
            moreButton.interactable = true;
            lessButton.interactable = true;
        }
    }


}
