using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : UIInventory
{

    Inventory playerInventory;
    // Start is called before the first frame update

  

    void Start()
    {
        
      

        playerInventory = FindObjectOfType<Inventory>();
    }

    public void UseToolbarItemSlot(int toolbarNumber)
    {
        int i = toolbarNumber - 1;

       Item itemToUse =  uiItems[i].item;

        if (itemToUse != null)
            UseItems.Use(itemToUse);

        else
            print("There is no item in toolbar slot " + toolbarNumber);
    }
  
   
     override public void AddNewItem(Item item)
    {
        if (!playerInventory.isToolbarFull)
        {
            try
            {
                UpdateItem(uiItems.FindIndex(i => i.item == null), item);
            }
            catch
            {
                playerInventory.isToolbarFull = true;
                print("The item was not added. ToolBar is full");
            }
        }
    }
    public void AddItemToToolbarSlot(Item itemToAdd, int toolbarSlot)
    {

        if (!playerInventory.isToolbarFull)
        {
            try
            {
                UpdateItem(toolbarSlot, itemToAdd);
            }
            catch
            {
                playerInventory.isToolbarFull = true;
                print("The item was not added. ToolBar is full");
            }
        }

    }

    public void RemoveItemFromToolbarSlot( int toolbarSlot)
    {
        if (!playerInventory.isToolbarFull)
        {
            try
            {
                UpdateItem(toolbarSlot, null);
            }
            catch
            {
                playerInventory.isToolbarFull = true;
                print("The item was not added. ToolBar is full");
            }
        }

    }

    override public void RemoveItem(Item item)
    {
        try
        {
            UpdateItem(uiItems.FindIndex(i => i.item == item), null);
            playerInventory.isInventoryFull = false;
        }
        catch
        {
            print("You do not have that item");
        }
    }

    override public void UpdateInventory()
    {
        try
        {
            print("trying to find a null toolbar item");
            Item nullItem =uiItems[uiItems.FindIndex(i => i.item == null)].GetItemInSlot();
            playerInventory.isToolbarFull = false;
            print("passed finding null toolbar item");
        }
        catch
        {
            print("Didn't find a null toolbar item");
            if (!playerInventory.isToolbarFull)
                playerInventory.isToolbarFull = true;
        }
    }

    public void PlaceOrRemoveToolbarItemSlot(int toolbarNumber, GameObject tableToPlaceOn)
    {
        Table currentTable = tableToPlaceOn.GetComponent<Table>();
        int slotNumber = toolbarNumber - 1;

        Item itemToUse = uiItems[slotNumber].item;

        if (itemToUse != null && !currentTable.hasItemOnTable)
        {
            PlaceItem.PotionToPlace(itemToUse, tableToPlaceOn);
            return;
        }
      
        else if (itemToUse == null && currentTable.hasItemOnTable)
        {
            PlaceItem.PotionToRemove(tableToPlaceOn, slotNumber);
            return;
        }

        else if (itemToUse != null && currentTable.hasItemOnTable && itemToUse != currentTable.itemOnTable)
        {
            PlaceItem.PotionToSwap(itemToUse, tableToPlaceOn, slotNumber);
            return;
        }


    }



}
