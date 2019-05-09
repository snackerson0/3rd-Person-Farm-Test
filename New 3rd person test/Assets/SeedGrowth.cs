using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    private Timer timer;
    [SerializeField] int plantHeight;
   

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckGrowTimer())
            { IncreasePlantSize(); };
    }



    //used to only display CheckGrowTimer() message once.
    bool displayTimerMessage = true;

    bool CheckGrowTimer()
    {
        if (timer.isFinished && displayTimerMessage)
        {
            print("The seed growth timer is also finished");
            displayTimerMessage = false;
            return true;
        }
        return false;
    }

    void IncreasePlantSize()
    {
        transform.localScale = new Vector3 (1,plantHeight,1);

    }
}



