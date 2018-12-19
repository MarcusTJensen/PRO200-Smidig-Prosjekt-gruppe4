using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMenuScript : MonoBehaviour
{

    public GameObject[] panels;

    private GameObject activePanel;
    private int panelIndex = 0;
    private bool isDraging, swipeLeft, swipeRight;
    private Vector2 startTouch, swipeDelta;
	
	void Start ()
	{
	    activePanel = panels[0];
	}
	

	void Update ()
	{
	    swipeLeft = swipeRight = false;

	    if (Input.touches.Length != 0)
	    {
	        if (Input.touches[0].phase == TouchPhase.Began)
	        {
	            isDraging = true;
	            startTouch = Input.touches[0].position;
	        }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
	        {
	            isDraging = false;
                Reset();
	        }
	    }

        //Calculate the distance
	    swipeDelta = Vector2.zero;
	    if (isDraging)
	    {
	        if (Input.touches.Length > 0)
	        {
	            swipeDelta = Input.touches[0].position - startTouch;
	        }
	    }

        //Reaction distance
	    if (swipeDelta.magnitude > 150)
	    {
            //Which direction
	        float x = swipeDelta.x;
	        float y = swipeDelta.y;
	        if (Mathf.Abs(x) > Mathf.Abs(y))
	        {
                //Left or right
	            if (x < 0) swipeLeft = true;
	            else swipeRight = true;
	        }

	        if (swipeLeft)
	        {
	            panelIndex++;
	        }else if (swipeRight)
	        {
	            panelIndex--;
	        }

	        ChangePanel();

            Reset();
	    }
    }

    private void ChangePanel()
    {
        if (panelIndex > panels.Length - 1)
        {
            panelIndex = panels.Length - 1;
        }

        if (panelIndex < 0)
        {
            panelIndex = 0;
        }

        activePanel.SetActive(false);
        activePanel = panels[panelIndex];
        activePanel.SetActive(true);


    }

    private void Reset()
    {
        startTouch = Vector2.zero;
    }

    public Vector2 SwipeDelta
    {
        get { return swipeDelta; }
    }

    public bool SwipeLeft
    {
        get { return swipeLeft; }
    }

    public bool SwipeRight
    {
        get { return swipeRight; }
    }
}
