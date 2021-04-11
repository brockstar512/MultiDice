using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Settings data = new Settings();
        data.RetrievePlayer();
        // Debug.Log(data);
        // Debug.Log(data.mRollSetting);
        // data.mRollSetting = RollSetting.Tap;
        // data.KeepSettings();

    }

}
