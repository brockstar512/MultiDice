using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 tilt;
    //public Vector3 nudge = (10,10,10);
    //public bool isNotThrown = true;
    //public Rigidbody rb;

    bool hasLanded;
    bool hasThrown;
    
    public bool stay;
    private TotalDiceHandler totalDiceHandler;

    [SerializeField] Vector3 initPosition;//throw location
    [SerializeField] GameObject buttonController;
    //[SerializeField] GameObject errorMessage;


    private float timePressed;
    private float timeUpPressed;
    private float pressedDifference;

    public int diceValue;
    public DiceRollCheck[] diceRollCheck;


    public GameObject KeepScoreAndEndRoundButton;

 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        
        rb.useGravity= false;//this will not have gravity at the start so it won't automatically fall but it will have kinetamic so it wont slide around  
        //rb.isKinematic = true;//the problem is if it is kinematic it can be effexted by force or torque
        //errorMessage.SetActive(false);//this was active
        if(buttonController == null) {
            buttonController = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(3).gameObject;
            KeepScoreAndEndRoundButton = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        }

        buttonController.SetActive(false);//this is null in instantiated die..this was active
        totalDiceHandler = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<TotalDiceHandler>();


    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[Input.touches.Length - 1].phase == TouchPhase.Began)
        {
            TouchBegan();

        }

        if (Input.touchCount > 0 && Input.touches[Input.touches.Length - 1].phase == TouchPhase.Ended)
        {

            TouchEnded();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.touches[Input.touches.Length - 1].phase == TouchPhase.Ended)//*****
        {
            RollDice();
        }

        if(rb.IsSleeping() && !hasLanded && hasThrown)
        {
            hasLanded = true;
            SideValueCheck();
            //rb.useGravity = false; //we dont need gravity of its laying down
        }

        //illegable roll
        else if(rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            //errorMessage.SetActive(true);
            RollAgain();
        }
        if (hasLanded && diceValue > 0) { buttonController.SetActive(true); }
        stay = transform.parent.gameObject.GetComponent<KeepDice>().saveDice;

    }

    
    void RollDice()
    {
        KeepScoreAndEndRoundButton.SetActive(false);//** this should be on but the instantiated dice is making this null
        if (!hasThrown && !hasLanded)
        {
            hasThrown = true;
            rb.useGravity= true;
            //if (isNotThrown)
            //{
            //Vector3 tilt = Input.acceleration;
            //tilt = Quaternion.Euler(90, 0, 0) * tilt;
            //-transform.forward
            Debug.Log("tilt -- " + tilt);
            //}
            //->tilt = new Vector3(Random.Range(0, 500),Random.Range(0, 500),Random.Range(0, 500));
            //I could do transform.down too
            //->rb.AddForce(transform.forward * tilt.x, ForceMode.Impulse);//divide it by the pressedDifference
            //rb.AddForce(transform.forward * 200, ForceMode.Impulse);
            rb.AddTorque(Random.Range(0,500),Random.Range(0,500),Random.Range(0,500));// give its random torque so its not falling straight down

        }
    }
    //this is not added to the button...i could iterate through the list and if its not null select round over
    public void roundOver()
    {
        if (hasThrown && hasLanded && !stay)
        {
            Reset();
        }
        else if (hasThrown && hasLanded && stay)
        {
            this.gameObject.SetActive(false);
            //totalDiceHandler.totalDice2.RemoveAt(this.gameObject.transform.parent.gameObject.transform.GetSiblingIndex());
            Destroy(this.gameObject.transform.parent.gameObject);
            //Debug.Log("this is sibling index         " + this.gameObject.transform.parent.gameObject.transform.GetSiblingIndex());
        }
    }

    void Reset()
    {
        
        transform.position = initPosition;
        hasThrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
        // errorMessage.SetActive(false);

    }

    public void ResetForNewPlayer()
    {
        this.transform.parent.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        this.gameObject.transform.parent.GetComponent<KeepDice>().ForceOutlineOff();
        Reset();
    }

    void RollAgain()
    {
        Reset();
        hasThrown = true;
        rb.useGravity= true;
        rb.AddTorque(Random.Range(0,500),Random.Range(0,500),Random.Range(0,500));
    }

    void SideValueCheck()
    {
        diceValue = 0;
        //loop over all the children with the dice roll check script and get the value
        foreach(DiceRollCheck side in diceRollCheck)
        {
            if(side.OnGround())
            {
                diceValue = side.sideValue;
            }
        }
    }


    public void TouchBegan()
    {
        timePressed = Time.time;
        Debug.Log(timePressed - timeUpPressed);
    }

    public void TouchEnded()
    {
        timeUpPressed = Time.time;
        Debug.Log(timePressed + "-----" + timeUpPressed);
        pressedDifference = timeUpPressed - timePressed;
        Debug.Log("time difference in pressed       " + pressedDifference);
    }

}
