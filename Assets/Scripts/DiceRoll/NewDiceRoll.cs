using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDiceRoll : MonoBehaviour
{
    bool hasLanded;
    bool hasThrown;
    Rigidbody rb;
    public int diceValue;
    public DiceRollCheck[] diceRollCheck;

    [SerializeField] Vector3 initPosition;//throw location


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;


        rb.useGravity = false;
        rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))//*****
        {
            Debug.Log("SPACE CLICKED");
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
            Debug.Log("-------- did not read value");
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
            Debug.Log("--------" + side.OnGround());

            if (side.OnGround())
            {
                Debug.Log("--------" + side.sideValue);

                diceValue = side.sideValue;
                //TODOdiceSelectionManager.ProvideDiceAsOption(diceValue);
                //Debug.Log("Checking dice value - " + diceValue);
                //Debug.Log("DICE HAS LANDED: " + diceValue);

            }
        }
    }

    void RollDice()
    {
        Debug.Log("Rolling");

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
