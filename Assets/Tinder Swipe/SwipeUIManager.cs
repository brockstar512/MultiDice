using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwipeUIManager : MonoBehaviour
{
    public TextMeshProUGUI inputFieldTextPlaceholder;
    private GameObject _nameContainer;
    public GameObject existingPlayersTemplate;


    
    void Start()
    {
        
        _nameContainer = this.gameObject.transform.GetChild(1).transform.gameObject.transform.GetChild(0).gameObject;
        
        PopulatePlayerList();
        int _playerNumber = _nameContainer.transform.childCount;
        inputFieldTextPlaceholder.text = "Player "+ _playerNumber.ToString();
    }

    void PopulatePlayerList()
    {
        for(int i =0; i < 15;i++)
        {
            GameObject player =  Instantiate(existingPlayersTemplate);
            player.transform.SetParent(_nameContainer.transform);

            player.SetActive(true);

        }
    }

}
