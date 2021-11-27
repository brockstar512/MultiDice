using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class ManagePacket : MonoBehaviour
{
    public LeanTweenType easeType;//ease in back is cool for buttons
    // out at 337  in at 107
    [SerializeField] TextMeshProUGUI gameTitle;
    [SerializeField] TextMeshProUGUI gameDescription;
    [SerializeField] Image backgroundImage;
    GameManager.GameType queueGame;

    GameObject loadingScreen;

    private void Update()
    {

        //Debug.Log($"Position:{this.transform.localPosition} and local position:{this.transform.position}");
    }
    private void OnEnable()
    {
        Debug.Log("Tween");
        //LeanTween.moveX(gameObject, 13.5f, 1f).setEase(easeType);

    }
    public void Distribute(ScreenPacket gamePacket)
    {
        this.gameTitle.text = gamePacket.gameTitle;
        this.gameDescription.text = gamePacket.gameDescription;
        this.queueGame = gamePacket.gameType;
    }

    public void MoveIn()
    {
        LeanTween.moveX(gameObject, 107, .3f).setEase(easeType);

    }

    public void MoveOut()
    {
        LeanTween.moveX(gameObject, 337, .3f).setEase(easeType);

    }

    public void PlayGame()
    {
        switch(this.queueGame)
        {
            case GameManager.GameType.Farkle:
                Debug.Log("This function will transport you to farkle");
                break;
            case GameManager.GameType.JustRoll:
                Debug.Log("This function will transport you to just roll");
                break;
            case GameManager.GameType.LiarsDice:
                Debug.Log("This function will transport you to liars dice");
                break;
            case GameManager.GameType.Threes:
                Debug.Log("This function will transport you to threes");
                break;
        }
        //SceneManager.LoadSceneAsync((int)this.queueGame,LoadSceneMode.Additive);
        SceneManager.LoadScene((int)this.queueGame);

    }

    public void LoadGame()
    {
        //loadingScreen.SetActive(true);
        //SceneManager.UnloadSceneAsync((int)this.queueGame);

    }

}
