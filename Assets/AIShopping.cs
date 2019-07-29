
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIShopping : MonoBehaviour
{
    public List<GameObject> people = new List<GameObject>();

    public Queue<GameObject> waitingLine;

    public Vector3[] linePostions = new Vector3[4];

    private NavMeshHit navHit = new NavMeshHit();

    public bool isPlayerBehindCounter = false;

    void Awake()
    {
        waitingLine = new Queue<GameObject>();
        SetLinePostions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessQueue()
    {
        GameObject[] waitingLineArry = waitingLine.ToArray();

       
        for(int i = 0; i< waitingLineArry.Length && i < linePostions.Length; i++)
        {
            if (Vector3.Distance(waitingLineArry[i].transform.position, linePostions[i]) > 2)
            {
               AI ai = waitingLineArry[i].GetComponent<AI>();
               ai.placeInQueue = i;
                
            }
                
        }
    }

    private void SetLinePostions()
    {
        linePostions[0] = new Vector3(6,1,-15);
        linePostions[1] = new Vector3(6, 1, -13);
        linePostions[2] = new Vector3(6, 1, -11);
           
    }
}
