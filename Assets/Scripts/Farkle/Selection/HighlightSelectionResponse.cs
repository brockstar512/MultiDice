using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlightMaterial;
    [SerializeField] public Material defaultMaterial;
    //game object parent not selected
    

    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if(selectionRenderer!=null)//&& !this.transform.parent.GetComponent<KeepDice>().saveDice
        {
            selectionRenderer.material = this.highlightMaterial;
        }  
    }
        public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if(selectionRenderer!= null)
        {
           selectionRenderer.material = this.defaultMaterial;
        }
    }
}
