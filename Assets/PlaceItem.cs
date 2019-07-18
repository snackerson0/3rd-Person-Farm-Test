using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{
    static private Inventory playerInventory;



    private void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>();
    }

    static public void PlaceAnyItem(Item item)
    {
        if (item.seedItem != null)
        {
            print("The seed script was found on the item");
            //PotionToPlace(item);
            return;
        }

        if (item.toolItem != null)
        {
            print("The tool script was found on the item");
        }

    }

    static public void PotionToPlace(Item item, GameObject table)
        {
        if (item.seedItem != null)
        {
            Table currentTable = table.GetComponent<Table>();
            Vector3 locationToPlaceAt = new Vector3(table.transform.position.x, 1, table.transform.position.z);

            currentTable.itemOnTable = item;

            GameObject createdObject = Instantiate(item.prefab, locationToPlaceAt, Quaternion.identity);
            createdObject.transform.SetParent(table.transform, true);
            currentTable.gameObjectOnTable = createdObject;

            playerInventory.RemoveItem(item);

          
            if (currentTable != null)
                currentTable.hasItemOnTable = true;
        }
        else
            print("There was no seed item to place on the table");
        }

    static public void PotionToRemove( GameObject table)
    {
        
        Table currentTable = table.GetComponent<Table>();

        playerInventory.AddItem(currentTable.itemOnTable);

        Destroy(currentTable.gameObjectOnTable);

        currentTable.hasItemOnTable = false;

        currentTable.itemOnTable = null;
    }

    static public void PotionToSwap(Item item, GameObject table)
    {
        if (item.seedItem != null)
        {
            //TODO Make slot take old item instead of first empty slot
            Table currentTable = table.GetComponent<Table>();
            Vector3 locationToPlaceAt = new Vector3(table.transform.position.x, 1, table.transform.position.z);


            Item oldItem = currentTable.itemOnTable;           
            Destroy(currentTable.gameObjectOnTable);
            currentTable.itemOnTable = null;
            currentTable.gameObjectOnTable = null;
            


            GameObject createdObject = Instantiate(item.prefab, locationToPlaceAt, Quaternion.identity);
            createdObject.transform.SetParent(table.transform, true);
            currentTable.gameObjectOnTable = createdObject;
            currentTable.itemOnTable = item;

            playerInventory.RemoveItem(item);
            playerInventory.AddItem(oldItem);

            if (currentTable != null)
                currentTable.hasItemOnTable = true;
        }
        else
            print("There was no seed item to place on the table");
    }
}
