using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    public bool isFinished = false;

    SeedGrowth growSeed;
  
     void Awake ()
	{

        // Gets and sets current object time to the time current in the world.
        
	    startTime = Time.time;
        isFinished = false;
        growSeed = GetComponent<SeedGrowth>();
	}
    
    

    void Update ()
	{
        
	    if (isFinished)
	        return;
	    // this gets the current time in the world compared to when the timer is first called.
	    float t = Time.time - startTime;
	    int minutes = (int) t / 60;
	    float seconds = t % 60;
	    if (seconds >= 5)
	    {


            
            Finish();
            growSeed.enabled = true;
            growSeed.IncreasePlantSize();
        }
	}

    public void Finish()
    {
        isFinished = true;
        print("plant finished");
        
    }
}
