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

    Item currentAssignedItem;

    [SerializeField]Currency playerCurrency;
    private void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>();
        itemDatabase = FindObjectOfType<ItemDatabase>();

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
            if (playerCurrency.GetPlayersBalance() >= currentAssignedItem.itemValue)
            {
                playerInventory.AddItem(itemIDNumber);
                playerCurrency.DeductMoneyFromPlayer(currentAssignedItem.itemValue);
                currentAssignedItem = null;
            }
            else
            {
                print("You broke boi.");
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
                playerInventory.RemoveItem(itemToSellID);
                playerCurrency.AddMoneyToPlayer(currentAssignedItem.itemValue);
                currentAssignedItem = null;
               
                
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
            return true;
        }
        else
        {
            return false;
        }
    }
}
