using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    enum RollSetting { Slider, Shake, Tap };

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetEffectsVolume(float volume)
    {

    }



}


