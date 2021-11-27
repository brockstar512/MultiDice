using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartRoll : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private ISwipeable diceCounter;//this could be an interface// then in that inhereted interface run the function


    void Awake()
    {
        diceCounter = this.transform.parent.GetComponent<ISwipeable>();
    }

    //while you drag this script runs
    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + eventData.delta.y);
        if (transform.localPosition.y - _initialPosition.y > 0)
        {

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.y - _initialPosition.y);
        Debug.Log("DISTANCE: " + _distanceMoved);
        Debug.Log("Screen height: " + Screen.height * .10);

        //snap back

        if (_distanceMoved < Screen.height * .10)
        {
            //reset the travel distance to the initial position if swipe not complete
            transform.localPosition = _initialPosition;
            //reset the rotation to 0 if the swipe is not complete
            transform.localEulerAngles = Vector3.zero;

        }
        else
        {
            //you started the game
            //diceCounter.StartGame();
            StartCoroutine(StartGame());

        }

    }

    private IEnumerator StartGame()
    {
        float time = 0;
        while (transform.localPosition.y < 175f)
        {
            time += Time.deltaTime;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 10f, 0);

            // transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
            // transform.localPosition.x+Screen.width,time),transform.localPosition.y,0);

            yield return null;
        }
        //Destroy(this.transform.gameObject);
       diceCounter.StartGame();


    }


}