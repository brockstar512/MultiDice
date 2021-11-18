using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //make one for sounds adn one for music
    public Sounds[] sounds;
    //pausing muysic and dampenning music

    public Sounds[] music;

    public Slider musicSlider;
    public Slider soundSlider;


    [SerializeField] 
    private Sounds currentMusic;
    //music is changed dynamilcally
    //sound effects are played at the level at whatever the sound effects pitch is at.

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        currentMusic.source = gameObject.AddComponent<AudioSource>();
        Debug.Log("current music has an audio source");
        //soundSlider.value = LoadItems.data.mSoundVolume;//whatever this is saved that is what the slider is going to equal
        musicSlider.value = LoadItems.data.mMusicVolume;

        //you have created a class for each sound... this will give each sound a audio source component and give a public variable for each var in that class
        //this will add a sound component for each sound clip in our array on awake
        foreach(Sounds s in sounds)
        {
           s.source =  gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           //s.source.volume = s.volume;
           s.source.volume = soundSlider.value;//distrubite the saved sound effect
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
        }
        //get the volume for the sliders after the music components have been created because the sliders on running on an on change function
        //sample fx will automatically play and be null if the iteration has not happened
        soundSlider.value = LoadItems.data.mSoundVolume;
        if(SceneManager.GetActiveScene().name == "Start")
        {
            Debug.Log("You are in the start scene");
            PlayMusic(0);//instead of making it a music I could just pass it into the audio and have it loop
        }
    }
  

    public void Play(string name)
    {
        //this is a public method that will play the sound you pass in as the string
        //it iterates through the array to find the sound with the same name and plays that sound
        //after making sure that sound has the volume level of the sound effects slider

        //find the audio class by the name you passed in and play it through the audio manager
        Sounds s = Array.Find(sounds, sound => sound.name == name);
       if(s==null){
            Debug.LogError("No sound titled " + name+" was found.");
           return;
       }
        s.source.volume = soundSlider.value;//this is going to let you controll the sound  in run time
        s.source.Play();
    }

    public void PlayMusic(int songNum)
    {
        //when the game begins this function is called with a number passed in.
        //the current music is an unnamed dynamic(which is why it is unnamed) class of the sounds class
        //that adds the clip to be the song in the indexed position of the number passed in.
        //
       currentMusic.source.clip = music[songNum].clip;//plays random songs
       if(songNum > music.Length-1){
           Debug.LogError("Track " + songNum+" was not found.");
           return;
       }
       //m.source.volume = musicSlider.value;//i think this part would be redundant if I had it in the update function
       currentMusic.source.Play();
    }

    public void UpdateMusic()
    {
        //the music slider is listening for this change and will adjust what the current
        //music is playing and equal the volume to what that value was changed to
        currentMusic.source.volume = musicSlider.value;
    }

    public void PlaySoundFXSample()
    {
        ///when you change the audio setting play a sound at that level the slider equals
        Play("sample");
    }


    //allow switch off - prevents you to toggle off if nothing else is pressed in the toggle group
}
