using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;
    
    private Transform _currentSelection;

    
    
    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    void Update()
    {

       if(_currentSelection != null){ _selectionResponse.OnDeselect(_currentSelection);}

        var ray = _rayProvider.CreateRay();
        RaycastHit hit;
        _selector.Check(ray);

        _currentSelection = _selector.GetSelection();
        if (_currentSelection != null){_selectionResponse.OnSelect(_currentSelection);}
    }
}









