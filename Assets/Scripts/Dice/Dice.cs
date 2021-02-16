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

    private float speed = 10.0f;//*

    bool hasLanded;
    bool hasThrown;
    
    public bool stay;
    private TotalDiceHandler totalDiceHandler;

    [SerializeField] Vector3 initPosition;//throw location
    [SerializeField] GameObject buttonController;
    //[SerializeField] GameObject errorMessage;
    [SerializeField] bool mobileDevice = true;



    [Header("Tap Roll")]
    private bool tapRoll = false;
    private float countDownTimer = 1f;
    private bool isThumbDown;
    private float timePressed;
    private float timeUpPressed;
    private float pressedDifference;
    private Vector3 initialPosition;
    private Vector3 finalPosition;

    [Header("Roll Value Logic")]
    public int diceValue;
    public DiceRollCheck[] diceRollCheck;

    [Header("UI Helpers")]
    public GameObject KeepScoreAndEndRoundButton;

    [Header("Swipe Roll")]
    private bool flickRoll = true;
    Vector2 startPos, endPos, direction;// touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; //to calculate swipe time to control throw force
    [SerializeField] float throwForceInXandY = 1f;
    [SerializeField] float throwForceInZ = 50f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        
        rb.useGravity= false;
        if(!mobileDevice) rb.isKinematic = true;
        //rb.isKinematic = true;//the problem is if it is kinematic it can be effexted by force or torque
        //errorMessage.SetActive(false);//this was active
        if (buttonController == null) {
            buttonController = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(3).gameObject;
            KeepScoreAndEndRoundButton = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        }

        buttonController.SetActive(false);
        totalDiceHandler = this.gameObject.transform.parent.gameObject.transform.parent.GetComponent<TotalDiceHandler>();

    }


    void Update()
    {
        if (mobileDevice)
        {
            //swiper
            //ticker
            //3. flick your wrist

            //3. what it is now

            if (tapRoll)
            {
                Vector3 tilt = Input.acceleration;
                tilt = Quaternion.Euler(90, 0, 0) * tilt;
                if (tilt.sqrMagnitude > 1)
                    tilt.Normalize();

                if (Input.touchCount > 0 && Input.touches[Input.touches.Length - 1].phase == TouchPhase.Began)
                {
                    TouchBegan();
                    isThumbDown = true;
                    //time for pressing down... countdown from 5

                }
                if ((Input.touchCount > 0 && Input.touches[Input.touches.Length - 1].phase == TouchPhase.Ended))
                {
                    isThumbDown = false;
                    TouchEnded();
                }
                if (isThumbDown)
                {
                    countDownTimer -= Time.deltaTime;
                    if (countDownTimer <= 0)
                    {
                        TouchEnded();
                        RollDice();
                        countDownTimer = 1f;
                    }
                }
            }

            if (flickRoll)
            {
                rb.isKinematic = false;
                //touch the screen
                if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //getting touch position and marking time when you touch t screen
                    touchTimeStart = Time.time;
                    startPos = Input.GetTouch(0).position;
                }
                //if you release your finger
                if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    //marking time when you release it
                    touchTimeFinish = Time.time;

                    //calculate swipe time interval
                    timeInterval = touchTimeFinish - touchTimeStart;

                    //getting release finger position
                    endPos = Input.GetTouch(0).position;

                    //calculating swipe direction in 2D space
                    direction = startPos - endPos;

                    //add force to dice rb in 3D space depending on swipe time, direction, and throw force
                    //rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);
                    RollDice();
                }

            }


        }
        if (!mobileDevice || tapRoll)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.touches[Input.touches.Length - 1].phase == TouchPhase.Ended))//*****
            {
                RollDice();
            }
        }
       

        if (rb.IsSleeping() && !hasLanded && hasThrown)
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
        KeepScoreAndEndRoundButton.SetActive(false);
        
        if (!hasThrown && !hasLanded)
        {
            hasThrown = true;
            rb.useGravity= true;
         
            
            if (mobileDevice)
            {

                if (tapRoll)
                {
                    Vector3 tilt = Input.acceleration;
                    tilt = Quaternion.Euler(90, 0, 0) * tilt;

                    float rollForce = Mathf.Abs((finalPosition.z - initialPosition.z) / pressedDifference * pressedDifference) * 100;

                    if (finalPosition.z - initialPosition.z < 0)
                    {
                        //rollForce += 25f;
                        rollForce += 10f;
                        tilt.x *= Random.Range(20, 100);
                        tilt.y *= Random.Range(20, 100);
                        tilt.z *= Random.Range(20, 100);
                    }
                    else { rollForce += 50f; }

                    Debug.Log("roll force ->     " + rollForce);
                    rb.AddForce(transform.forward * (rollForce), ForceMode.Impulse);
                    rb.AddTorque(tilt.x * Random.Range(100, 500), tilt.y * Random.Range(100, 500), tilt.z * Random.Range(100, 500));
                }
                else if (flickRoll)
                {
                    
                    //throwForceInZ *= 10;
                    Debug.Log("z-> "+throwForceInZ);
                    Debug.Log("x and y-> " + throwForceInXandY);
                    Debug.Log("direction-> " + direction);
                    Debug.Log("timeInterval-> " + timeInterval);
                    Debug.Log("z FORCE -> " + (throwForceInZ / timeInterval));
                    Debug.Log("Official Force being applied -> " + (600-(throwForceInZ / timeInterval)));
                    //absolute value of 900 - z force
                    //add force to dice rb in 3D space depending on swipe time, direction, and throw force
                    //-direction.y * throwForceInXandY
                    rb.AddForce(-direction.x * throwForceInXandY, 1, 600-(throwForceInZ / timeInterval));
                    //direction
                    rb.AddTorque(Random.Range(100, 500),Random.Range(100, 500),Random.Range(100, 500));

                }

            }
            //10 mass on roll
            //1 mass on tap

            else
            {
                //computer roll
                rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));// give its random torque so its not falling straight down

            }
        }
    }

    public void roundOver()
    {
        if (hasThrown && hasLanded && !stay)
        {
            Reset();
        }
        else if (hasThrown && hasLanded && stay)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject.transform.parent.gameObject);
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
                //Debug.Log("Checking dice value - " + diceValue);

            }
        }
    }


    public void TouchBegan()
    {
        timePressed = Time.deltaTime;
        initialPosition = Input.acceleration;
        initialPosition = Quaternion.Euler(90, 0, 0) * initialPosition;

        if (initialPosition.sqrMagnitude > 1) initialPosition.Normalize();//**not sure if this is needed?

        //private Vector3 initialPosition;
        //private Vector3 finalPosition;

        Debug.Log(timePressed - timeUpPressed);
   
    }

    public void TouchEnded()
    {
        isThumbDown = false;
        finalPosition = Input.acceleration;
        finalPosition = Quaternion.Euler(90, 0, 0) * finalPosition;

        if (finalPosition.sqrMagnitude > 1) finalPosition.Normalize();//**not sure if this is needed?

        timeUpPressed = Time.deltaTime;
        pressedDifference = timeUpPressed - timePressed;
    }




}
