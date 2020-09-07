using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
//https://www.youtube.com/watch?v=EANtTI6BCxk
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //              i dont know if i want out hit because i want the ray cast to return a variable value
        if (Physics.Raycast(ray, out hit,100.0f))//how far a ray will go before it stops
        {
            if(hit.transform != null)
            {
                PrintName(hit.transform.gameObject);
            }
        }
    }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);//(i think i could just click the side value
    }
}
