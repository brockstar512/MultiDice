using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;//will measure the velocity

    bool hasLanded;
    bool hasThrown;
    //we need access to the dice value on all the children and we do that by creating an array
    
    public bool stay; //if clicked this will destroy the dice
    //this is important

    Vector3 initPosition;//throw location
    [SerializeField] GameObject buttonController;
    [SerializeField] GameObject errorMessage;
    



    public int diceValue;
    public DiceRollCheck[] diceRollCheck;
    //the array is added in the inspector then you add which scripts that have that script you want in the array list
    //this will create an empty array you then populate that array by dragging the game objects in that lsit
    //this will break if you put an object in the array and you try and access something within the script of that object that does not exist

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity= false;//this will not have gravity at the start so it won't automatically fall but it will have kinetamic so it wont slide around  
        rb.isKinematic = true;
        errorMessage.SetActive(false);
        

    }

    void Update()
    {
        //update rolls the side if space is pressed. it will check the value if the dice
        //has landed and if there is an error when rolled. the dice will be rerolled.
        // it will also keep track of whhich dice has stay active from the keep dice.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
            //this will roll dice and reset dice
            //it also rerolls but i may change that


        }

        if(rb.IsSleeping() && !hasLanded && hasThrown)
        {
            //this runs when we have thrown the rb has stopped rolling. this says not has landed but that immediatly becomes true in here
            //is sleeping just means if the rb hasn't moved
            hasLanded = true;//when you throw it change has landed to true
            SideValueCheck();
            //rb.useGravity = false; //we dont need gravity of its laying down


        }
        else if(rb.IsSleeping() && hasLanded && diceValue == 0)//if the dice is sleeping and the value is unreadable, reroll;
        //if dice value is not being checked in update the dice will run everytime the rb stops bc dice value does not change from zero
        {//error roll
            //errorMessage.SetActive(true);
            RollAgain();
            //it might be good to add a message so it doesn't look like a glitch
        }


        if (hasLanded && diceValue > 0) { buttonController.SetActive(true); }
            //after we roll we get a button that says score whats selected or end round.

        


        //stay is going to equal if you want to keep the dice from its parent keep dice
        stay = transform.parent.gameObject.GetComponent<KeepDice>().saveDice;

    }

    
    void RollDice()
    {  
        //this function rolls the dice. if it has not landed and if it has not landed.
        //it make it gives the item gravity and a torque to throw it
        if (!hasThrown && !hasLanded)//if it has not been thrown and is not landed roll
        {
            hasThrown = true;
            rb.useGravity= true;//now it will fall
            rb.AddTorque(Random.Range(0,500),Random.Range(0,500),Random.Range(0,500));// give its random torque so its not falling straight down
            //This is the force that it rolls^
        }
    }

    public void roundOver()
    {
        //this function resets the dice that are not clicked. it destroys the dice that are.
        //it also tells dice handler that the round is over.

        ////RESETS WHEN THROW / LANDED  / DON"T WANT IT TO STAY
        if (hasThrown && hasLanded && !stay)
        {
            Reset();
        }
        // DESTOYS THE DICE WHEN THROWN / LANDED  / WANT TO KEEP FOR SCORING.
        else if (hasThrown && hasLanded && stay)
        {
            Destroy(transform.parent.gameObject);//i can pass info into function as an argument or an array, but right now I'm just going to completely destroy the items
        }
        //TotalDiceHandler.roundOver = true;
    }

    void Reset()
    {
        transform.position = initPosition;//put back to its original popsition
        hasThrown = false;
        hasLanded = false;
        rb.useGravity = false; //this will allow it to flow before rolling the dice
        rb.isKinematic = false;
        // errorMessage.SetActive(false);
          
    }

    void RollAgain()
    {
        Reset();
        hasThrown = true;
        rb.useGravity= true;//now it will fall
        rb.AddTorque(Random.Range(0,500),Random.Range(0,500),Random.Range(0,500));// 
    }

    void SideValueCheck()
    {
        diceValue = 0;
        //loop over all the children with the dice roll check script and get the value
        foreach(DiceRollCheck side in diceRollCheck)
        {
            if(side.OnGround())
            {
                // one of the side has a trigger that when it hits th collider will be true
                // this dice value in this script eqals the side value that is true
                //in the array. this dice value eqauls the side value variable in that script
                diceValue = side.sideValue;
                //Debug.Log(diceValue + " has been rolled");
                //diceValue and dice value is important
            }
        }
    }
}

//this dice script has an array of dice. it will iterate over the array and only the array that is attached to it.
//so you can have multiple dice and they won't get confused cause this logic is contained in the dice prefab and its children. there is no logic in the 
//floor board other than it is a collider that will trigger the trigger on the sides of the dice.