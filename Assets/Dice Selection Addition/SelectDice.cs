using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelectDice : MonoBehaviour
{
    public Sprite[] diceSprites;
    public TotalDiceHandler totalDiceHandler;
    public int destroyDiceSubstitute = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
        for(int i = 0; i < this.gameObject.transform.childCount;i++){
            int randomNum = UnityEngine.Random.Range(0,6);//dice you that was rolled will populate a sprite with that number
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            child.transform.GetComponent<Image>().sprite= diceSprites[randomNum];
        }
        */
        
    }

    public void ActivateAvailableDice(int diceNumber)
    {
        //Debug.Log("BUTTON MANAGER HAS: " + diceNumber);
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            //if the sprite is a default sprite change it otherwise continue
            if(this.gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == diceSprites[0])
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = diceSprites[diceNumber];
                return;
            }
        }

    }

    public void KeepDice()
    {
            for(int i = 0; i < this.gameObject.transform.childCount;i++){
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            Sprite graphic = child.transform.GetComponent<Image>().sprite;
            int selectedNumber = Array.FindIndex(diceSprites, s => s.name == graphic.name);
            //diceSprites.IndexOf(graphic);

            if(child.transform.GetComponent<Toggle>().isOn)
            {
                //Debug.Log("You Are Keeping Dice: "+selectedNumber);//based off that sprite keep dice will keep that rolls
                //what do i want to do with the kept dice?
                totalDiceHandler.KeepDiceSelection(selectedNumber);
                destroyDiceSubstitute++;


            }


            //you something will the numbers then... turn everything off
            child.transform.GetComponent<Toggle>().isOn = false;//turn all togles off
        }
        DestroyDiceSubstitute();
        //Debug.Log("FINISHED WITH DICE: ");
        totalDiceHandler.ScoreTimePlaceholder();
        //totalDiceHandler.KeepDiceAndScore();

    }

    //because they arent being manually selected anymore in order to work with the previosu ogic I have to take away as many dice as I have selected
    void DestroyDiceSubstitute()
    {
        GameObject diceParent = transform.parent.transform.parent.transform.parent.GetChild(0).gameObject;
        for (int i = 0; i < destroyDiceSubstitute; i++)
        {
            Debug.Log("Destroying child index:" + i);
            Destroy(diceParent.transform.GetChild(i).gameObject);
        }
        destroyDiceSubstitute = 0;
    }
}
