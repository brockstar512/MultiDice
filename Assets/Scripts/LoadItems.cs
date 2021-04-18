using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadItems : MonoBehaviour
{


    [Header("Loading settings")]
    public static Settings data;
    // Start is called before the first frame update

    [Header("Master settings")]
    [SerializeField] Slider saveMusicValue;
    [SerializeField] Slider saveAudioValue;
    //this is so you can get the index of get active roll
    [SerializeField] Toggle[] toggleGroup;

    void Awake()
    {
        data = new Settings();
        data.RetrieveSettings();
        //data.mMusicVolume = .5f;
        //data.mSoundVolume = .5f;

        Debug.Log("Roll setting " + data.mRollSetting);

        if (toggleGroup.Length <= 1)
            Debug.LogError("You have not set the toggles into the array");
        //not doing anything
        //figure out how to make it so it wont toggle off it you click it a second time.
        //make an on toggle function that wont toggle off when clicked event
        foreach (Toggle toggle in toggleGroup)
        {
            if (toggle.transform.GetSiblingIndex() == (int)data.mRollSetting)
                toggle.isOn = true;
            else
                toggle.isOn = false;
        }
    }


    public void AdjustSettings()
    {

        var toggleNum = -1;
        foreach (Toggle toggle in toggleGroup)
        {
            if (toggle.isOn)
            {
                toggleNum = toggle.transform.GetSiblingIndex();
            }
        }
        switch (toggleNum)
        {
            case 0:
                Debug.Log("Setting Swipe");
                data.mRollSetting = RollSetting.Swipe;
                break;
            case 1:
                Debug.Log("Setting Shake");
                data.mRollSetting = RollSetting.Shake;
                break;
            case 2:
                Debug.Log("Setting Tap");
                data.mRollSetting = RollSetting.Tap;
                break;
            case 3:
                Debug.Log("Setting Computer");
                data.mRollSetting = RollSetting.Computer;
                break;
            default:
                Debug.Log("No Toggle Selected");
                break;
        }

        data.mMusicVolume = saveMusicValue.value;
        data.mSoundVolume = saveAudioValue.value;

        data.KeepSettings();
        Debug.Log("KEEP THESE SETTINGS");
    }


    //maybe i dont need audio manager here but i can add the musdic fx

}
