using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID;

    public string itemName;
    public string description;

    public Sprite icon;

    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public Item(int ID, string itemName, string description, Dictionary<string,int> stats)
    {
        this.ID = ID;
        this.itemName = itemName;
        this.description = description;
       // this.icon =  Resources.Load<Sprite>("Assets / Resources / Sprites / sprite01.png");
        this.stats = stats;
      this.icon = Resources.Load<Sprite>("Sprites/Items/" + itemName);
    }

    public Item(Item item)
    {
        this.ID = item.ID;
        this.itemName = item.itemName;
        this.description = item.description;
        // this.icon =  Resources.Load<Sprite>("Assets / Resources / Sprites / sprite01.png");
        this.stats = item.stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + itemName);
    }
}
