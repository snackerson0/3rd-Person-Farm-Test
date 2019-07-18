using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Item itemOnTable;
    public GameObject gameObjectOnTable;

    Player player;
    public bool hasItemOnTable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            player = other.GetComponent<Player>();
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
