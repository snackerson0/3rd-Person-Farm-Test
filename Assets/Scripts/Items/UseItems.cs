using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItems : MonoBehaviour
{
    static private Farming farming;
    static private Inventory playerInventory;

    private void Awake()
    {
        farming = FindObjectOfType<Farming>();
        playerInventory = FindObjectOfType<Inventory>();
    }

 //TODO Still need to make seed not infinte. 
    static public void Use(Item item)
    {
        if(item.seedItem != null)
        {
            print("The seed script was found on the item");
            UseSeedItem(item);
            return;
        }
     
        if(item.toolItem != null)
        {
            print("The tool script was found on the item");
        }
        
    }

   static private void UseNullItem()
    {
        print("the item does not have a type or use function");
    }

    static private void UseSeedItem(Item item)
    {
        print("The seed item use was used.");
        farming.seedToCreate = item.prefab;
        playerInventory.RemoveItem(item);      

    }
}