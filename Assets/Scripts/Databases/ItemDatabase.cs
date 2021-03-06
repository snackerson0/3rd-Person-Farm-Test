﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    //TODO test to see if Tools display in inventory and use properly
    public  List<Item> items = new List<Item>();

    static private SeedDatabase seedDatabase;
    static private ToolDatabase toolDatabase;

    [SerializeField] private GameObject turnipSeed;
    [SerializeField] private GameObject tomatoSeed; 
   void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int itemID)
    {
        // iterate through list.
      return  items.Find(item => item.ID == itemID);
    }

    public Item GetItem(string itemName)
    {
        Item itemToAdd =  items.Find(item => item.itemName == itemName);
        return itemToAdd;
    }

   
   virtual protected void BuildDatabase()
    {
        items = new List<Item>()
        {/*
            new Item(0, "Diamond Ore", "So pretty ^u^",
                new Dictionary<string, int>
                {
                    {"Value", 300}
                }),
*/
            new Item(1, "Gold Ore", "Smelt to make gold bars",20, 0, tomatoSeed, new Dictionary<string, int>{{"Value", 20}} ),
            
            new Item(2, "cartoon seeds", "A pack of seeds", 30, 0, turnipSeed, new Dictionary<string, int>{{"Value",20}}),

            new Item(3, "Tomato","It is a tomato", 40, 0,tomatoSeed, new Dictionary<string, int>{{"Value",60}}),

            new Item(4, "Turnip","It is a turnip", 65, 0, turnipSeed,new Dictionary<string, int>{{"Value",60}})
        };
    }

    static public Item SearchAllDatabases(string itemName)
    {
        Item searchedItem;
      searchedItem = SearchSeedDataBase(itemName);
        if (searchedItem != null)
            return searchedItem;

        searchedItem = SearchToolDataBase(itemName);
        if (searchedItem != null)
            return searchedItem;

        return null;
    }

    static public Item SearchAllDatabases(int itemID)
    {
        Item searchedItem;
        searchedItem = SearchSeedDataBase(itemID);
        if (searchedItem != null)
            return searchedItem;

        searchedItem = SearchToolDataBase(itemID);
        if (searchedItem != null)
            return searchedItem;

        return null;
    }


    static public Item SearchSeedDataBase(string itemToSearchFor)
    {
        Item searchedItem = seedDatabase.items.Find(item => item.itemName == itemToSearchFor);
        return searchedItem;
    }
   static public Item SearchSeedDataBase(int itemIDToSearchFor)
    {
        Item searchedItem = seedDatabase.items.Find(item => item.ID == itemIDToSearchFor);
        return searchedItem;
    }
   


    static public Item SearchToolDataBase(string itemToSearchFor)
    {
        Item searchedItem = toolDatabase.items.Find(item => item.itemName == itemToSearchFor);
        return searchedItem;
    }
    static public Item SearchToolDataBase(int itemIDToSearchFor)
    {
        Item searchedItem = toolDatabase.items.Find(item => item.ID == itemIDToSearchFor);
        return searchedItem;
    }

}
