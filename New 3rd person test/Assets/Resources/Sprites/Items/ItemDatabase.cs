using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
   void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int itemID)
    {
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
        {
            new Item(0, "Diamond Ore", "So pretty ^u^",
                new Dictionary<string, int>
                {
                    {"Value", 300}
                }),

            new Item(1, "Gold Ore", "Smelt to make gold bars", new Dictionary<string, int>{{"Value", 200}} )

        };
    }
}
