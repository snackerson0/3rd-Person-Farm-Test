﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : Item
{
    Inventory playerInventory;

    void Start()
    {
        
    }

    public SeedItem(int ID, string itemName, string description, int itemBaseValue, int itemQuality, GameObject prefab, Dictionary<string, int> stats)
    {
        this.ID = ID;
        this.itemName = itemName;
        this.description = description;
        this.prefab = prefab;
        this.itemBaseValue = itemBaseValue;
        this.itemQuality = itemQuality;
        this.stats = stats;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + itemName);
        itemType = "Seed";

        SetSeedItem(this);
    }

    public override void UseItem()
    {
        
    }
}
