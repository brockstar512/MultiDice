using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

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



    void Awake()
    {
        currentMusic.source = gameObject.AddComponent<AudioSource>();
        
        //you have created a class for each sound... this will give each sound a audio source component and give a public variable for each var in that class
        //this will add a sound component for each sound clip in our array on awake
        foreach(Sounds s in sounds)
        {
           s.source =  gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
        }

        // foreach(Sounds m in music)
        // {
        //    m.source =  gameObject.AddComponent<AudioSource>();
        //    m.source.clip = m.clip;
        //    m.source.volume = m.volume;
        //    m.source.pitch = m.pitch;
        //    m.source.loop = m.loop;
        // }

        
    }
  
//this is a public method that will play the sound you pass in as the string
    public void Play(string name)
    {
        //find the audio class by the name you passed in and play it through the audio manager
       Sounds s = Array.Find(sounds, sound => sound.name == name);
       if(s==null){
           Debug.Log("No sound titled " + name+" was found.");
           return;
       }
        s.source.volume = soundSlider.value;//this is going to let you controll the sound  in run time
        s.source.Play();
    }
        public void PlayMusic(int songNum)
    {
       currentMusic.source.clip = music[songNum].clip;//plays random songs
       if(songNum > music.Length-1){
           Debug.Log("Track " + songNum+" was not found.");
           return;
       }
       //m.source.volume = musicSlider.value;//i think this part would be redundant if I had it in the update function
       currentMusic.source.Play();
    }

    public void UpdateMusic()
    {
        currentMusic.source.volume = musicSlider.value;
    }





}
