using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "ScreenPacket", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

[CreateAssetMenu(fileName = "ScreenPacket")]
public class ScreenPacket : ScriptableObject
{
    public GameManager.GameType gameType;
    public string gameTitle;
    public string gameDescription;
    public string howToPlay;
    public Image backgroundImage;
    public Image instructionSheet;




}
