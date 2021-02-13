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



    void OnEnable()
    {
        buttons.SetActive(true);
    }

    public void Pause()
    {
        this.gameObject.SetActive(true);
    }

    public void Resume()
    {
        this.gameObject.SetActive(false);
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
