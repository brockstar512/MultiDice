using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    private ISelectionResponse _selectionResponse; 
    private Transform _selection;


private void Awake()
{
    _selectionResponse = GetComponent<ISelectionResponse>();
}
    void Update()
    {
         //if(Input.GetMouseButtonDown(0))
        //{ //this is broken because of the clicking
        //selection/deselection response

       if(_selection != null)
       {
           _selectionResponse.OnDeselect(_selection);
       }

            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//creating a ray and casting it into the scene
            //deterining what was selected
            _selection = null;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,100.0f))//how far a ray will go before it stops
            {
                var selection = hit.transform;//the variable grabs the transform of whatever you hit
                if(selection.CompareTag(selectableTag))//if what your clicking on has the tag selectable
                {
                    _selection = selection;//if whatever you clivked on has a selectable tag then _selection eqauls that
                }
            }
          
            //selection/deselection response
            //if you have selected something
            //then it'll pass it on to selection response
            if(_selection != null)
            {
                _selectionResponse.OnSelect(_selection);
            }
        //}
    }
}

//youtube
//https://www.youtube.com/watch?v=QDldZWvNK_E