﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();

    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;


    private Farming farming;

    private void Awake()
    {
        farming = GetComponent<Farming>();
    }

    void Start()
    {
        GiveItem("cartoon seeds");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UseItem(2);
        }
    }
    public void GiveItem(int ID)
    {
        Item itemToAdd = itemDatabase.GetItem(ID);
        inventoryUI.AddNewItem(itemToAdd);


        characterItems.Add(itemToAdd);
        print("Add the item: "+itemToAdd.itemName );
    }


    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        inventoryUI.AddNewItem(itemToAdd);


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

            inventoryUI.RemoveItem(itemToRemove);

            print("Removed item: "+ itemToRemove.itemName);
        }
    }

    public void UseItem(int itemID)
    {
        Item itemToUse = CheckForItem(itemID);

        if(itemToUse != null)
        {
            farming.seedToCreate = itemToUse.prefab;

            RemoveItem(itemID);
        }
        
    }
}

