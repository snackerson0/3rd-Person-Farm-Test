using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Item itemOnTable;
    public GameObject gameObjectOnTable;
    public Vector3 tableLocation;

    Player player;
    AI ai;
    public bool hasItemOnTable = false;

    private void Start()
    {
        tableLocation = this.gameObject.transform.position;
        print("The table is at location " + tableLocation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player = other.GetComponent<Player>();

        if (other.tag == "AI")
        {
            ai = other.GetComponent<AI>();
            if (ai.desiredItem == itemOnTable)
            {
                ai.currentItem = itemOnTable;
                ai.hasDesiredItem = true;
                ai.isBrowsingStore = false;
                Destroy(gameObjectOnTable);
                itemOnTable = null;

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" )
        {
            player.PlaceItem(this.gameObject);
            return;
           
        }
        
    }

   
}
