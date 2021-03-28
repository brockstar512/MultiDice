using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //make one for sounds adn one for music
    public Sounds[] sounds;
    //pausing muysic and dampenning music
    
    public Sounds[] music;
    // Start is called before the first frame update
    void Awake()
    {
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
       s.source.Play();
    }


}
