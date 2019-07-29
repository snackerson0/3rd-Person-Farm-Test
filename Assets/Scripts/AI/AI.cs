
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public int placeInQueue;

    private NavMeshAgent navAgent;

    public List<Table> allTables = new List<Table>();

    public Item desiredItem, currentItem;

    public AIShopping checkoutLine;

    private SeedDatabase seedDatabase;

    [SerializeField]GameObject player;

    NavMeshHit navHit = new NavMeshHit();

    [SerializeField] public bool readyToCheckout = false, isBrowsingStore = true, isInLine = false, deque = false, hasDesiredItem = false, hasMovedAlready = false;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        seedDatabase = FindObjectOfType<SeedDatabase>();
        desiredItem = seedDatabase.GetItem(1);
        checkoutLine = new AIShopping();
    }

    // Update is called once per frame
    void Update()
    {
        // Add a random range from 1- 10 for the x and z position.

     

        if (placeInQueue == 0 && Vector3.Distance(gameObject.transform.position, checkoutLine.linePostions[placeInQueue]) < 2 && !navAgent.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            checkoutLine.waitingLine.Dequeue();
            Destroy(this.gameObject);
            checkoutLine.ProcessQueue();
        }

        if (!hasDesiredItem)
        {


            if (isBrowsingStore)
            {
                Table searchedItem = allTables.Find(table => table.itemOnTable == desiredItem);

                //Possibly see if you can run outside of update for more effiency. 
                if (searchedItem != null && !hasMovedAlready)               
                    StartCoroutine(DelayAIMovement(6, searchedItem));

                    else if( searchedItem == null)
                if (NavMesh.SamplePosition(player.transform.position, out navHit, 2, NavMesh.AllAreas))
                        navAgent.SetDestination(navHit.position);
                
                
            }
            else if (!isBrowsingStore)
                if (NavMesh.SamplePosition(player.transform.position, out navHit, 2, NavMesh.AllAreas))
                    navAgent.SetDestination(navHit.position);
        }
        else if (hasDesiredItem)
        {
            if (!isInLine)
            {
                checkoutLine.waitingLine.Enqueue(this.gameObject);
                checkoutLine.people.Add(this.gameObject);
                checkoutLine.ProcessQueue();
                isInLine = true;
            }

            if (Vector3.Distance(gameObject.transform.position, checkoutLine.linePostions[placeInQueue]) < 1.5 && navAgent.enabled)
            {
       
               //avAgent.enabled = false;

            }
            else
            {
                if (navAgent.enabled == false)
                    navAgent.enabled = true;


                if (NavMesh.SamplePosition(checkoutLine.linePostions[placeInQueue], out navHit, 2, NavMesh.AllAreas))
                    navAgent.SetDestination(navHit.position);
            }

        }
    }

    private IEnumerator DelayAIMovement(float delay, Table table)
    {
        hasMovedAlready = true;
        yield return new WaitForSeconds(delay);

        if (NavMesh.SamplePosition(table.tableLocation, out navHit, 2, NavMesh.AllAreas)) ;
        navAgent.SetDestination(navHit.position);

        hasMovedAlready = false;
    }

}
