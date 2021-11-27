using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDiceRoll : MonoBehaviour
{
    bool hasLanded;
    public bool hasThrown;
    Rigidbody rb;
    public int diceValue;
    public DiceRollCheck[] diceRollCheck;
    private DiceSelectionManager diceSelectionManager;

    public Vector3 initPosition { get; private set; }//throw location
    


    private void Awake()
    {
        diceSelectionManager = Camera.main.GetComponent<DiceSelectionManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initPosition = this.transform.parent.gameObject.transform.position;

        rb = GetComponent<Rigidbody>();
        


        rb.useGravity = false;
        rb.isKinematic = true;
        Debug.Log($"POS:{initPosition} for game object {this.transform.parent.gameObject.name}");
        //initPosition = this.transform.parent.gameObject.transform.localPosition;
        //Debug.Log($"Local POS:{initPosition} for game object {this.transform.parent.gameObject.name}");


    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))//*****
        {
            //Debug.Log("SPACE CLICKED");
            RollDice();
        }
        if (rb.IsSleeping() && !hasLanded && hasThrown)
        {
            //Debug.Log("--------####");

            //has landed....
            hasLanded = true;
            SideValueCheck();
            //rb.useGravity = false; //we dont need gravity of its laying down

        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            //Debug.Log("-------- did not read value");
            //errorMessage.SetActive(true);
            RollAgain();
        }
        //====




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

    void SideValueCheck()
    {
        diceValue = 0;
        //loop over all the children with the dice roll check script and get the value
        foreach (DiceRollCheck side in diceRollCheck)
        {

            if (side.OnGround())
            {

                diceValue = side.sideValue;
                //Debug.Log("--------> the dice is on the ground  "+side.sideValue);this 

                //TODO
                diceSelectionManager.ProvideDiceAsOption(diceValue);
                //Debug.Log("Checking dice value - " + diceValue);
                //Debug.Log("DICE HAS LANDED: " + diceValue);

            }
        }
    }

    void RollDice()
    {
        //Debug.Log("Rolling");

        if (!hasThrown && !hasLanded)
        {
            hasThrown = true;
            rb.useGravity = true;

            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));// give its random torque so its not falling straight down
            
        }
    }
    void RollAgain()
    {
        Reset();
        hasThrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    public void roundOver()
    {
        if (hasThrown && hasLanded)
        {
            Reset();
        }
        else if (hasThrown && hasLanded)
        {
            Debug.Log("DESTROYING THE DICE**");
            this.gameObject.SetActive(false);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }

}
