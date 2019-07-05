using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID;

    public string itemName;
    public string description;
    public GameObject prefab;
    public Sprite icon;
    public int itemBaseValue, itemQualityValue;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    public int itemQuality; 


    public Item(int ID, string itemName, string description, int itemBaseValue, int itemQuality, GameObject prefab, Dictionary<string,int> stats)
    {
        this.ID = ID;
        this.itemName = itemName;
        this.description = description;
        this.prefab = prefab;
        this.itemBaseValue = itemBaseValue;
        this.itemQuality = itemQuality;
        this.stats = stats;
      this.icon = Resources.Load<Sprite>("Sprites/Items/" + itemName);
    }

    public Item(Item item)
    {
        this.ID = item.ID;
        this.itemName = item.itemName;
        this.description = item.description;
        this.prefab = item.prefab;
        // this.icon =  Resources.Load<Sprite>("Assets / Resources / Sprites / sprite01.png");
        this.stats = item.stats;
        this.itemBaseValue = item.itemBaseValue;
        this.itemQuality = 0;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + itemName);
    }

    private void SetItemQualityValue()
    {

    }
}
