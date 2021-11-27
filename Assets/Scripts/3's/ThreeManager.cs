using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeManager : MonoBehaviour
{

    [SerializeField] GameObject diceGroupPrefab;
    [SerializeField] GameObject singleDice;
    private GameObject currentDice;

    Dictionary<int, Vector3> diceDict = new Dictionary<int, Vector3>();
    [ContextMenu("Start Game")]//
    private void Awake()
    {
        StartGame();
    }
    public void StartGame()
    {
        NewDice();
        GetDiceLocation();

    }

    [ContextMenu("NewDice")]
    public void NewDice()
    {
        currentDice = Instantiate(diceGroupPrefab);
        //for(int i = 0;i < currentDice.transform.childCount; i++)
        //{
        //    diceDict.Add(i + 1, currentDice.transform.GetChild(i).GetComponent<NewDiceRoll>().initPosition);
        //}
        
    }

    void GetDiceLocation()
    {
        for (int i = 0; i <= currentDice.transform.childCount-1; i++)
        {
            Debug.Log($"Here is i {i} and here is the game object {currentDice.transform.GetChild(i).GetChild(0).transform.parent.gameObject.name}");
            diceDict.Add(i + 1, currentDice.transform.GetChild(i).GetChild(0).transform.parent.gameObject.transform.position);
        }
    }

    [ContextMenu("Remaining Children")]//
    public bool NoDiceRemain()
    {
        return currentDice.transform.childCount == 0 ? true : false;
    }

    [ContextMenu("Get Five Back")]//
    public void GetFiveDiceBack()
    {
        NewBatchOfDice(5);
    }

    public void NewBatchOfDice(int howMany)
    {
        int i = 1;
        while(i <= howMany)
        {
            BringBackOneDice();
            i++;
        }

    }
    [ContextMenu("Bring Back One Dice")]    
    public void BringBackOneDice()
    {
        if (currentDice.transform.childCount >= 6)
            return;

        //we instatiate a single dice at the 
        GameObject newDice = Instantiate(singleDice, diceDict[currentDice.transform.childCount + 1], Quaternion.identity, currentDice.transform);
    }


}
