using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory playerInventory;

    [SerializeField] int itemIDNumber;
    [SerializeField] int itemToSellID;
    ItemDatabase itemDatabase;

    Item currentAssignedItem, playerItem;

    Toolbar toolbar;

    [SerializeField]Currency playerCurrency;
    private void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>();
        itemDatabase = FindObjectOfType<ItemDatabase>();
        toolbar = FindObjectOfType<Toolbar>();
    }
    void Start()
    {
        
    }

    public Item CheckForItem(int itemID)
    {
        currentAssignedItem = itemDatabase.items.Find(item => item.ID == itemID);
        return itemDatabase.items.Find(item => item.ID == itemID);
    }
    public void BuyItem()
    {
        CheckForItem(itemIDNumber);

        if (currentAssignedItem != null)
        {
            if (playerCurrency.GetPlayersBalance() >= currentAssignedItem.itemBaseValue && !playerInventory.isInventoryFull || !playerInventory.isToolbarFull)
            {
                playerInventory.AddItem(itemIDNumber);
                playerCurrency.DeductMoneyFromPlayer(currentAssignedItem.itemBaseValue);
                currentAssignedItem = null;
            }
            else
            {
                print("You don't have enough money or your inventory/toolbar are both full.");
            }
        }
    }

    public void SellItem()
    {
        CheckForItem(itemToSellID);
        
        if (currentAssignedItem != null)
        {
            if (playerCurrency != null && PlayerHasItem(itemToSellID))
            {
                if (playerItem.itemQuality == 0)
                {
                    playerCurrency.AddMoneyToPlayer(currentAssignedItem.itemBaseValue);
                    playerInventory.RemoveItem(playerItem.itemName);                  
                    currentAssignedItem = null;
                }
                
                else if(playerItem.itemQuality > 0)
                {
                    playerCurrency.AddMoneyToPlayer(playerItem.itemQualityValue);
                    playerInventory.RemoveItem(playerItem.itemName);                   
                    currentAssignedItem = null;
                }

            }
            else
            {
                print("You do not have that item to sell or we can't find your currency");
            }
        }
    }

    bool PlayerHasItem(int itemID)
    {
       Item itemToSearchFor = playerInventory.characterItems.Find(item => item.ID == itemID);
        if (itemToSearchFor != null)
        {
            playerItem = playerInventory.characterItems.Find(item => item.ID == itemID);
            return true;
        }
        else
        {
            return false;
        }
    }
}
