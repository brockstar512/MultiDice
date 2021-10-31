using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datastore : MonoBehaviour
{
    private static Datastore instance = null;
    private static readonly object padlock = new object();
    private Game currentGame;

    Datastore()
    {
        Debug.Log("Created Datastore");
    }

    public static Datastore Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Datastore();
                }
                return instance;
            }
        }
    }

    public void Initialize()
    {
        //this.currentGame = game;
    }
}

abstract class Game
{
    
}
