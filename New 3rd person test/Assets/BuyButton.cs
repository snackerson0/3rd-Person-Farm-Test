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
    SeedDatabase seedDatabase;

    Item currentAssignedItem, playerItem;

    Toolbar toolbar;

    [SerializeField]Currency playerCurrency;
    private void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>();
        itemDatabase = FindObjectOfType<ItemDatabase>();
        toolbar = FindObjectOfType<Toolbar>();
        seedDatabase = FindObjectOfType<SeedDatabase>();
    }
    void Start()
    {
        
    }

    public Item CheckForItem(int itemID)
    {
        currentAssignedItem = seedDatabase.items.Find(item => item.ID == itemID);
    
        return currentAssignedItem;      
    }
    public Item CheckNormalDatabase(int itemID)
    {
        currentAssignedItem = itemDatabase.items.Find(item => item.ID == itemID);
        return currentAssignedItem;
    }


    public void BuyItem()
    {
        CheckForItem(itemIDNumber);

        if (currentAssignedItem != null)
        {
            if (playerCurrency.GetPlayersBalance() >= currentAssignedItem.itemBaseValue)
            {
                if (!playerInventory.isInventoryFull || !playerInventory.isToolbarFull)
                {
                    playerInventory.AddItem(currentAssignedItem);
                    playerCurrency.DeductMoneyFromPlayer(currentAssignedItem.itemBaseValue);
                    currentAssignedItem = null;
                }
            }
            else
            {
                print("You don't have enough money.");
            }
        }
    }

    public void SellItem()
    {
        CheckNormalDatabase(itemToSellID);
        
        if (currentAssignedItem != null)
        {
            print("got to first sell check");
            if (playerCurrency != null && PlayerHasItem(currentAssignedItem.itemName))
            {
                print("Got to second sell check");
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

    bool PlayerHasItem(string itemName)
    {
       Item itemToSearchFor = playerInventory.characterItems.Find(item => item.itemName == itemName);
        if (itemToSearchFor != null)
        {
            playerItem = playerInventory.characterItems.Find(item => item.itemName == itemName);
            return true;
        }
        else
        {
            return false;
        }
    }
}
