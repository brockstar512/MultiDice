using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
//https://www.youtube.com/watch?v=EANtTI6BCxk
{

    [SerializeField] Material highlightMaterial;
    [SerializeField] Material defaultMaterial;
    [SerializeField] private string selectableTag = "Selectable"; 
    
    private Transform selected;

    void Update()
    {
       if(selected != null)
       {
           var selectionRenderer = selected.GetComponent<Renderer>();
           selectionRenderer.material = defaultMaterial;
           selected = null;
       }
        if (Input.GetMouseButtonDown(0)) { 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //  i dont know if i want out hit because i want the ray cast to return a variable value
        if (Physics.Raycast(ray, out hit,100.0f))//how far a ray will go before it stops
        {
            var selection = hit.transform;//the variable grabs the transform of whatever you hit

            if(selection.CompareTag(selectableTag))//if what your clicking on has the tag selectable
            {
          
            var selectionRenderer = selection.GetComponent<Renderer>();
            if(selectionRenderer != null){
                selectionRenderer.material = highlightMaterial;
            }
            selected = selection;
            }
        }
    }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);//(i think i could just click the side value
    }
}
//hit.transform.GetComponent(Variables);

//var values: Dice = hit.transform.GetComponent(Variables);