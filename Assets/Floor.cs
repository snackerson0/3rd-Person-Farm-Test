
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public List<Table> currentTables = new List<Table>();


    [SerializeField] AIShopping shopDesk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            AI ai = other.GetComponent<AI>();
            ai.allTables = currentTables;
            ai.checkoutLine = shopDesk;
        }

        if (other.tag == "Table")
        {
            currentTables.Add(other.gameObject.GetComponent<Table>());           
        }

      
    }

}
