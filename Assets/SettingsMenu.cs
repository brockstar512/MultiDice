using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static RollSetting rollSetting;

    [Header("Current Player settings")]
    [SerializeField] Toggle[] toggleGroup;
    [SerializeField] ChangePlayerController changePlayerController;




    void OnEnable()
    {
        Debug.Log(changePlayerController.GetCurrentPlayer.rollSetting);
        //GetActiveRollSetting();
        switch (changePlayerController.GetCurrentPlayer.rollSetting)
        {
            case RollSetting.Swipe:
                toggleGroup[0].isOn = true;
                toggleGroup[1].isOn = false;
                toggleGroup[2].isOn = false;
                toggleGroup[3].isOn = false;
                break;
            case RollSetting.Shake:
                toggleGroup[1].isOn = true;
                toggleGroup[0].isOn = false;
                toggleGroup[2].isOn = false;
                toggleGroup[3].isOn = false;
                break;
            case RollSetting.Tap:
                toggleGroup[2].isOn = true;
                toggleGroup[1].isOn = false;
                toggleGroup[0].isOn = false;
                toggleGroup[3].isOn = false;
                break;
            case RollSetting.Computer:
                toggleGroup[3].isOn = true;
                toggleGroup[1].isOn = false;
                toggleGroup[2].isOn = false;
                toggleGroup[0].isOn = false;
                break;

        }
    }

        public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetEffectsVolume(float volume)
    {

    }

    public void GetActiveRollSetting()
    {
        var toggleNum = -1;
        foreach (Toggle toggle in toggleGroup)
        {
            if (toggle.isOn)
            {
                toggleNum = toggle.transform.GetSiblingIndex();
            }
        }

        switch(toggleNum)
        {
            case 0:
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Swipe;
                //ChangePlayerController.currentPlayerRollSettings = RollSetting.Swipe;
                break;
            case 1:
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Shake;
                break;
            case 2:
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Tap;
                break;
            case 3:
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Computer;
                break;
            default:
                Debug.Log("No Toggle Selected");
                break;

        }

    }
    void OnDisable()
    {
        GetActiveRollSetting();
    }

}
public enum RollSetting { Swipe, Shake, Tap, Computer };


