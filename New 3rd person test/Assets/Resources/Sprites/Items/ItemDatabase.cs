using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
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
        return items.Find(item => item.itemName == itemName);
    }

    public List<Item> items = new List<Item>();
    void BuildDatabase()
    {
        items = new List<Item>()
        {/*
            new Item(0, "Diamond Ore", "So pretty ^u^",
                new Dictionary<string, int>
                {
                    {"Value", 300}
                }),
*/
            new Item(1, "Gold Ore", "Smelt to make gold bars",tomatoSeed, new Dictionary<string, int>{{"Value", 20}} ),
            
            new Item(2, "cartoon seeds", "A pack of seeds",turnipSeed, new Dictionary<string, int>{{"Value",20}}),

            new Item(3, "Tomato","It is a tomato",tomatoSeed,new Dictionary<string, int>{{"Value",60}}),

            new Item(4, "Turnip","It is a turnip",turnipSeed,new Dictionary<string, int>{{"Value",60}})
        };
    }
}
