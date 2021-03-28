using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//if we want to see a class in the inspector we have to type system.serializable
[System.Serializable]
public class Sounds 
{
    public AudioClip clip;

    public string name;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    //we want to his public variables that will populate automatically to clear up inspector space
    [HideInInspector]
    public AudioSource source;
}
