using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchManager : MonoBehaviour
{
    public GameObject mainMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadHistory()
    {
        SceneManager.LoadScene("GameFinished");
    }

    public void LoadMainMenu()
    {
        //if this scene is start
        this.gameObject.transform.parent.gameObject.SetActive(false);
        mainMenu.SetActive(true);
        //else
        //load index 0

    }

}
