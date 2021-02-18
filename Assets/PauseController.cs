using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject buttons;
    public GameObject settingsPanel;
    public GameObject rulesPanel;

    public static bool gameIsPaused = false;

    void OnEnable()
    {
        buttons.SetActive(true);
        gameIsPaused = true;
    }

    public void Pause()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        gameIsPaused = false;
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        buttons.SetActive(false);
    }

    public void Rules()
    {
        rulesPanel.SetActive(true);
        buttons.SetActive(false);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void BackToPause()
    {
        if (settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
        }
        else if (rulesPanel.activeSelf)
        {
            rulesPanel.SetActive(false);
        }
        buttons.SetActive(true);
    }
}
