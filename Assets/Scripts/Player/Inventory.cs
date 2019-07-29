using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();

    public SeedDatabase seedDatabase;
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;
    public Toolbar toolbarInventory;

    public bool isInventoryFull = false, isToolbarFull = false;

    private Farming farming;

    private void Awake()
    {
        farming = GetComponent<Farming>();
        seedDatabase = FindObjectOfType<SeedDatabase>();
    }

    void Start()
    {
        Item itemToAdd = seedDatabase.GetItem(2);
        inventoryUI.AddNewItem(itemToAdd);


        characterItems.Add(itemToAdd);
        print("Add the item: " + itemToAdd.itemName);
    }


    private void Update()
    {
     
    }
    public void AddItem(int ID)
    {
        Item itemToAdd = seedDatabase.GetItem(ID);
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

    public void AddItem(Item item)
    {          
        UpdateInventory();
        if (!isToolbarFull)
        {
            toolbarInventory.AddNewItem(item);
            characterItems.Add(item);

            print("Add the item: " + item.itemName + " with quality ");
        }

        else if (!isInventoryFull)
        {
            inventoryUI.AddNewItem(item);
            characterItems.Add(item);

            print("Add the item: " + item.itemName + " with quality ");
        }
        else
            print("Both of your inventories are full");
    }
    
    public void AddItemToToolbarSlot(Item itemToAdd, int toolbarSlot)
    {
        UpdateInventory();
        if (!isToolbarFull)
        {
            toolbarInventory.AddItemToToolbarSlot(itemToAdd, toolbarSlot);
            characterItems.Add(itemToAdd);


        }

        else if (!isInventoryFull)
        {
            inventoryUI.AddNewItem(itemToAdd);
            characterItems.Add(itemToAdd);

            print("Add the item: " + itemToAdd.itemName);
        }
        else
            print("Both of your inventories are full");
}

    public void RemoveItemFromToolbarSlot(Item itemToRemove, int toolbarSlot)
    {
        UpdateInventory();
             
        toolbarInventory.RemoveItemFromToolbarSlot(toolbarSlot);
        characterItems.Remove(itemToRemove);

        print("Removed the item: " + itemToRemove.itemName);
        
    }

    public Item CheckForItem(int itemID)
    {
        return characterItems.Find(item => item.ID == itemID);
    }
    public Item CheckForItem(string itemName)
    {
        return characterItems.Find(item => item.itemName == itemName);
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
    public void RemoveItem(int itemNumber)
    {
        Item itemToRemove = CheckForItem(itemNumber);

        if (itemToRemove != null)
        {
            UIItem uiItem = toolbarInventory.uiItems.Find(item => item.item == itemToRemove);
            UIItem uiInventoryItem = inventoryUI.uiItems.Find(item => item.item == itemToRemove);
            try
            {
                if (uiItem.item != null)
                {
                    characterItems.Remove(itemToRemove);
                    toolbarInventory.RemoveItem(itemToRemove);
                    print("Removed item: " + itemToRemove.itemName);
                    return;
                }
            }
            catch
            {
                if (uiInventoryItem.item != null)
                {
                    {
                        characterItems.Remove(itemToRemove);
                        inventoryUI.RemoveItem(itemToRemove);
                        print("Removed item: " + itemToRemove.itemName);
                        return;
                    }
                }
            }

            print("The item could not be found in the inventory but the player has the item in inventory");
        }
        else
            print("The player does not have that item to remove");
    }

    public void RemoveItem(string itemName)
    {
        Item itemToRemove = CheckForItem(itemName);

        if (itemToRemove != null)
        {
            UIItem uiItem = toolbarInventory.uiItems.Find(item => item.item == itemToRemove);
            UIItem uiInventoryItem = inventoryUI.uiItems.Find(item => item.item == itemToRemove);
            try
            {
                if (uiItem.item != null)
                {
                    characterItems.Remove(itemToRemove);
                    toolbarInventory.RemoveItem(itemToRemove);
                    print("Removed item: " + itemToRemove.itemName);
                    return;
                }
            }
            catch {
                if (uiInventoryItem.item != null)
                {
                    {
                        characterItems.Remove(itemToRemove);
                        inventoryUI.RemoveItem(itemToRemove);
                        print("Removed item: " + itemToRemove.itemName);
                        return;
                    }
                }
            }
           
               print("The item could not be found in the inventory but the player has the item in inventory");
        }
        else
            print("The player does not have that item to remove");
    }

    public void RemoveItem(Item itemToBeRemoved)
    {
        Item itemToRemove = CheckForItem(itemToBeRemoved.itemName);

        if (itemToRemove != null)
        {
            UIItem uiItem = toolbarInventory.uiItems.Find(item => item.item == itemToRemove);
            UIItem uiInventoryItem = inventoryUI.uiItems.Find(item => item.item == itemToRemove);
            try
            {
                if (uiItem.item != null)
                {
                    characterItems.Remove(itemToRemove);
                    toolbarInventory.RemoveItem(itemToRemove);
                    print("Removed item: " + itemToRemove.itemName);
                    return;
                }
            }
            catch
            {
                if (uiInventoryItem.item != null)
                {
                    {
                        characterItems.Remove(itemToRemove);
                        inventoryUI.RemoveItem(itemToRemove);
                        print("Removed item: " + itemToRemove.itemName);
                        return;
                    }
                }
            }

            print("The item could not be found in the inventory but the player has the item in inventory");
        }
        else
            print("The player does not have that item to remove");
    }


    public void AddQualityItem(string itemName, int qualityToAdd)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);

        Item newItemToAdd = new Item(itemToAdd);

        newItemToAdd.itemQuality += qualityToAdd;

        ItemQuality(newItemToAdd.itemQuality, newItemToAdd);

        UpdateInventory(); 
        if(!isToolbarFull)
        {
            toolbarInventory.AddNewItem(newItemToAdd);
                characterItems.Add(newItemToAdd);

                print("Add the item: " + newItemToAdd.itemName + " with quality " + newItemToAdd.itemQuality + "to inventory");
        }

        else if (!isInventoryFull)
        {
            inventoryUI.AddNewItem(newItemToAdd);
            characterItems.Add(newItemToAdd);

            print("Add the item: " + newItemToAdd.itemName + " with quality " + newItemToAdd.itemQuality + "to inventory");
        }
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

    public void UpdateInventory()
    {
        inventoryUI.UpdateInventory();
        toolbarInventory.UpdateInventory();
         
            



    }
}

