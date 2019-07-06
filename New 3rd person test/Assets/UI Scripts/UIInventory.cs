using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    private Inventory playerInventory;
   [SerializeField] private int numberOfSlots;


   protected void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
        playerInventory = FindObjectOfType<Inventory>();
    }

    public void UpdateItem(int slot, Item item)
    {
        uiItems[slot].UpdateItemSlot(item);
    }

    virtual public void AddNewItem(Item item)
    {
        try
        {
            UpdateItem(uiItems.FindIndex(i => i.item == null), item);
            playerInventory.isInventoryFull = false;
        }
        catch
        {
            playerInventory.isInventoryFull = true;
            print("The item was not added. Inventory is full");
        }
       
    }

   virtual public void RemoveItem(Item item)
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

    virtual public void UpdateInventory()
    {
        try
        {
            print("trying to find a null inventory item");
            Item nullItem = uiItems[uiItems.FindIndex(i => i.item == null)].GetItemInSlot();
            playerInventory.isInventoryFull = false;
            print("passed finding null inventory item");
        }
        catch
        {
            print("Didn't find a null inventory item");
            if(!playerInventory.isInventoryFull)
            playerInventory.isInventoryFull = true;
        }
    }
}
