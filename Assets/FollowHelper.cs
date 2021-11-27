using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHelper : MonoBehaviour, IFollow
{
    public Camera cam;
    public MultipleTargetCamera targetCameraScript;
    public NewDiceRoll dice;
    private bool isThrown;
    // Start is called before the first frame update
    void Awake()
    {
        GetCamera();
        GetDiceLogic();
    }
    void  LateUpdate()
    {

        this.isThrown = dice.hasThrown; //public get private set
        //this will run every frame until I roll it
        if (!targetCameraScript.targets.Contains(this.transform))
        {
            //once I roll this will be true and but the above if statemtn wont run anymore
            if (isThrown)
            {
                InitializeFollow();
                //isThrown = false;
            }
        }
    }
    public void GetCamera()
    {
        cam = Camera.main;
        targetCameraScript = Camera.main.GetComponent<MultipleTargetCamera>();
        
    }
    public void GetDiceLogic()
    {
        dice = this.GetComponent<NewDiceRoll>();
    }
    public void InitializeFollow()
    {
        targetCameraScript.targets.Add(this.transform);
    }
    private void OnDestroy()
    {//on disable
        targetCameraScript.targets.Remove(this.transform);
    }
}
