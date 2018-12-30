using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    public bool isFinished = false;

    
	
	void Start ()
	{
        // Gets and sets current object time to the time current in the world.
	    startTime = Time.time;
	}
	
	

	void Update ()
	{
        
	    if (isFinished)
	        return;
	    // this gets the current time in the world compared to when the timer is first called.
	    float t = Time.time - startTime;
	    int minutes = (int) t / 60;
	    float seconds = t % 60;
	    if (minutes == 1)
	    {
	       
            Finish();
   	    }
	}

    public void Finish()
    {
        isFinished = true; 
    }
}
