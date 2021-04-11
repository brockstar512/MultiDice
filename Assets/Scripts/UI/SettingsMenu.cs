using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public AudioManager AudioManager;
    //loop through all the sounds and make the sound and pitch equal what the range in the bar is

    public static RollSetting rollSetting;

    [Header("Current Player settings")]
    [SerializeField] Toggle[] toggleGroup;
    [SerializeField] ChangePlayerController changePlayerController;
    private int lastSettingSelected;
    
    private float volume;
    //private float volume;





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
                // lastSettingSelected = 0;
                break;
            case RollSetting.Shake:
                toggleGroup[1].isOn = true;
                toggleGroup[0].isOn = false;
                toggleGroup[2].isOn = false;
                toggleGroup[3].isOn = false;
                // lastSettingSelected = 1;
                break;
            case RollSetting.Tap:
                toggleGroup[2].isOn = true;
                toggleGroup[1].isOn = false;
                toggleGroup[0].isOn = false;
                toggleGroup[3].isOn = false;
                // lastSettingSelected = 2;
                break;
            case RollSetting.Computer:
                toggleGroup[3].isOn = true;
                toggleGroup[1].isOn = false;
                toggleGroup[2].isOn = false;
                toggleGroup[0].isOn = false;
                // lastSettingSelected = 3;
                break;

        }
    }

        public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        //settings volume
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
                Debug.Log("Setting 0");
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Swipe;
                lastSettingSelected = (int)RollSetting.Swipe;
                ChangePlayerController.currentPlayerRollSettings = RollSetting.Swipe;
                break;
            case 1:
                Debug.Log("Setting 1");
                //this is to change the class players setting
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Shake;
                lastSettingSelected = (int)RollSetting.Shake;
                //this is for the current round...otherwise the get current roll setting only runs when you run display player
                ChangePlayerController.currentPlayerRollSettings = RollSetting.Shake;

                break;
            case 2:
                Debug.Log("Setting 2");
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Tap;
                lastSettingSelected = (int)RollSetting.Tap;
                ChangePlayerController.currentPlayerRollSettings = RollSetting.Tap;
                break;
            case 3:
                Debug.Log("Setting 3");
                changePlayerController.GetCurrentPlayer.rollSetting = RollSetting.Computer;
                lastSettingSelected = (int)RollSetting.Computer;
                ChangePlayerController.currentPlayerRollSettings = RollSetting.Computer;
                break;
            default:
                Debug.Log("No Toggle Selected");
                toggleGroup[lastSettingSelected].isOn = true;
                ChangePlayerController.currentPlayerRollSettings = (RollSetting)lastSettingSelected;
                break;

        }

    }
    void OnDisable()
    {
        GetActiveRollSetting();
    }

}
public enum RollSetting { Swipe, Shake, Tap, Computer };


