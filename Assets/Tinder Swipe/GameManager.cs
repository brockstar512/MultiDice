using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //todo ... use this to register the game type
    public enum GameType
    {
        None,
        JustRoll,
        Farkle,
        Threes,
        LiarsDice
    }
    public GameType currentGame;
    //TODO make game more secure
    public static GameData data;
    //    public static Datastore Instance
    //{
    //    get
    //    {
    //        lock (padlock)
    //        {
    //            if (instance == null)
    //            {
    //                instance = new Datastore();
    //            }
    //            return instance;
    //        }
    //    }
    //}

    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        InitializeGame();
        currentGame = data.currentGame;

    }
    private void Update()
    {
        currentGame = data.currentGame;
    }

    //this should be a factory
    public void InitializeGame()
    {
         
        data = new GameData();
        //data.RefreshData();//
    }
}
