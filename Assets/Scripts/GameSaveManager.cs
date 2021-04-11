using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[System.Serializable]
public class Settings
{

    public RollSetting mRollSetting;
    public float mMusicVolume;
    public float mSoundVolume;

    //default settings constructor
    public Settings ()
    {
        mRollSetting = RollSetting.Computer;
        mMusicVolume = .5f;
        mSoundVolume = .5f;
    }

    public Settings (Settings setting)
    {
        mRollSetting = setting.mRollSetting;
        mMusicVolume = setting.mMusicVolume;
        mSoundVolume = setting.mSoundVolume;
    }

    public void KeepSettings()
    {
        SaveSystem.SaveSettings(this);
    }

    public void RetrievePlayer()
    {
        Settings data = SaveSystem.LoadSettings();
        mRollSetting = data.mRollSetting;
        mMusicVolume = data.mMusicVolume;
        mSoundVolume = data.mSoundVolume;
        // if(data.RollSetting == null){
        // }
    }

}

[System.Serializable]
public class GameHistory
{
    public List<GameData> games;
}

public static class SaveSystem
{

    
    public static void SaveSettings(Settings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath  + "/settings.txt";
        FileStream stream = new FileStream(path, FileMode.Create);
        Settings data = new Settings(settings);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static Settings LoadSettings()
    {
        string path = Application.persistentDataPath  + "/settings.txt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Settings data = formatter.Deserialize(stream) as Settings;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("File does not exists in " + path);
            //return default settings?
            Settings data = new Settings();
            SaveSettings(data);
            //return null;
            return data;

        }

    }
}

// public class GameSaveManager : MonoBehaviour {
//     public void KeepSettings()
//     {
//         //SaveSystem.SaveSettings(//settings class you want to pass in);
//         //volume
//         //if it doesnt have the local file it needs default values
//         //it needs to have a master setting that gives a default roll type
//         //default audio level
//         //default music level
//     }
// }