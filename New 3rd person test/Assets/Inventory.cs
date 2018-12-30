using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();

    public ItemDatabase itemDatabase;

    void Start()
    {
        GiveItem(0);
        RemoveItem(1);
    }

    public void GiveItem(int ID)
    {
        Item itemToAdd = itemDatabase.GetItem(ID);

        characterItems.Add(itemToAdd);
        print("Add the item: "+itemToAdd.itemName );
    }


    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);

        characterItems.Add(itemToAdd);
        print("Add the item: " + itemToAdd.itemName);
    }


    public Item CheckForItem(int itemID)
    {
        return characterItems.Find(item => item.ID == itemID);
    }

    public void RemoveItem(int itemID)
    {
        Item itemToRemove = CheckForItem(itemID);

        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            print("Removed item: "+ itemToRemove.itemName);
        }
    }
}

