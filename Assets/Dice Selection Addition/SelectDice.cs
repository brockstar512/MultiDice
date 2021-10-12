using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelectDice : MonoBehaviour
{
    public Sprite[] diceSprites;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < this.gameObject.transform.childCount;i++){
            int randomNum = UnityEngine.Random.Range(0,6);//dice you that was rolled will populate a sprite with that number
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            child.transform.GetComponent<Image>().sprite= diceSprites[randomNum];
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
                Debug.Log("You Are Keeping Dice: "+selectedNumber);//based off that sprite keep dice will keep that rolls
            }
            
            
            //you something will the numbers then... turn everything off
            child.transform.GetComponent<Toggle>().isOn = false;//turn all togles off
        }

    }
}
