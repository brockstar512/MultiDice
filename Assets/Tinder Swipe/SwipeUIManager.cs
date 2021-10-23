using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwipeUIManager : MonoBehaviour
{
    private GameObject inputFieldParent;
    private TextMeshProUGUI inputFieldTextPlaceholder;
    private TextMeshProUGUI inputFieldTextInput;
    private GameObject _nameContainer;
    public GameObject existingPlayersTemplate;


    
    void Start()
    {
        this.inputFieldParent = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        int childCount = inputFieldParent.transform.childCount;
        this.inputFieldTextPlaceholder = inputFieldParent.transform.GetChild(childCount-2).GetComponent<TextMeshProUGUI>();
        this.inputFieldTextInput = inputFieldParent.transform.GetChild(childCount-1).GetComponent<TextMeshProUGUI>();
        
        int playerIndex = GameManager.data.players.Count - 1;
        Debug.Log("HOW MANY ARE IN THE LIST "+GameManager.data.players.Count);
        this.inputFieldTextPlaceholder.text = GameManager.data.players[playerIndex].playerName;
        int i = 0;
        foreach(PlayerData name in GameManager.data.players){
            Debug.Log("PlayerName === "+i+"       "+name.playerName);
            i++;
        }
    }

    public void AddPlayer()
    {
        Debug.Log(inputFieldTextInput.text);
                Debug.Log(GameManager.data.players.Count);

        if(inputFieldTextInput.text == "")
            GameManager.data.AddPlayer(inputFieldTextPlaceholder.text);
        else
            GameManager.data.AddPlayer(inputFieldTextInput.text);

    }
    public void DeletePlayer()
    {
        int playerIndex = GameManager.data.players.Count - 1;
        //GameManager.data.players.RemoveAt(playerIndex);
        GameManager.data.DeletePlayer(playerIndex);


    }

}
