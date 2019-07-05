using System.Collections;
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
        AddItem("cartoon seeds");
        AddItem("Gold Ore");
    }

    int testUseItem = 1;
    bool firstUsedItem = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !firstUsedItem)
        {
            UseItem(2);
            firstUsedItem = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && firstUsedItem)
        {
            UseItem(1);
        }
    }
    public void AddItem(int ID)
    {
        Item itemToAdd = itemDatabase.GetItem(ID);
        inventoryUI.AddNewItem(itemToAdd);


        characterItems.Add(itemToAdd);
        print("Add the item: "+itemToAdd.itemName );
    }


    public void AddItem(string itemName)
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
            farming.NewSeedToUse(itemToUse.prefab);

            RemoveItem(itemID);
        }
        
    }

    public void AddQualityItem(string itemName, int qualityToAdd)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);

        Item newItemToAdd = new Item(itemToAdd);

        newItemToAdd.itemQuality += qualityToAdd;

        ItemQuality(newItemToAdd.itemQuality, newItemToAdd);

        inventoryUI.AddNewItem(newItemToAdd);


        characterItems.Add(newItemToAdd);
        print("Add the item: " + newItemToAdd.itemName +" with quality " + newItemToAdd.itemQuality);
    }

    private void ItemQuality(int currentQuality, Item item)
    {
        switch (currentQuality)
        {
            case 0: item.itemQualityValue = item.itemBaseValue; break;

            case 1: item.itemQualityValue = Mathf.RoundToInt(item.itemBaseValue + (item.itemBaseValue * .25f)); break;

            case 2: item.itemQualityValue = Mathf.RoundToInt(item.itemBaseValue + (item.itemBaseValue * .50f)); break;
        }
    }
}

