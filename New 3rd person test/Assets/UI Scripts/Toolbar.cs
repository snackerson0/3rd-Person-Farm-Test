using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : UIInventory
{
    UIInventory uIInventory;

    Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
        uIInventory = GetComponent<UIInventory>();

        playerInventory = FindObjectOfType<Inventory>();
    }

    public void UseToolbarItemSlot(int toolbarNumber)
    {
        int i = toolbarNumber - 1;

       Item itemToUse =  uIInventory.uiItems[i].item;

        if (itemToUse != null)
            playerInventory.RemoveItem(itemToUse.itemName);

        else
            print("There is no item in toolbar slot " + toolbarNumber);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

     override public void AddNewItem(Item item)
    {
        if (!playerInventory.isToolbarFull)
        {
            try
            {
                UpdateItem(uIInventory.uiItems.FindIndex(i => i.item == null), item);
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
            UpdateItem(uIInventory.uiItems.FindIndex(i => i.item == item), null);
            playerInventory.isInventoryFull = false;
        }
        catch
        {
            print("You do not have that item");
        }
    }
}
