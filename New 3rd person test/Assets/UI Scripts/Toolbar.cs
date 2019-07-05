using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
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
            playerInventory.UseToolbarItem(itemToUse.itemName);

        else
            print("There is no item in toolbar slot " + toolbarNumber);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
