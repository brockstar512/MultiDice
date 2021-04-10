using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{

    public static GameSaveManager instance;
    public static Settings settings;
    public static GameHistory history;

    void Awake()
    {
        settings = new Settings();
        Debug.Log(Application.persistentDataPath);
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this);
        }
        SaveGame();
        DontDestroyOnLoad(this);
    }
    public bool IsSaveFile()
    {
    return Directory.Exists(Application.persistentDataPath + "/game_save");
    }
    public void SaveGame()
    {
        if(!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        if(!Directory.Exists(Application.persistentDataPath + "/game_save/settings"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/settings_save.txt");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/game_save/settings/settings_save.txt");
        var json = JsonUtility.ToJson(settings);
        bf.Serialize(file,json);
        file.Close();
    }

    public void LoadGame()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/game_save/settings"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/settings");
        }
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath+"/game_save/settings/settings_save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_save/settings/settings_save.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file),settings);//settings is the obect to put it back onto
            file.Close();

        }
    }
}

[System.Serializable]
public class Settings
{
    public RollSetting mRollSetting;
    public float mMusicVolume;
    public float mSoundVolume;

}

[System.Serializable]
public class GameHistory
{
    public List<GameData> games;
}
