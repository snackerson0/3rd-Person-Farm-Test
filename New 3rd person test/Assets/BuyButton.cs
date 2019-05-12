using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory playerInventory;
    [SerializeField] int itemIDNumber;
    private void Awake()
    {
        playerInventory = FindObjectOfType<Inventory>();
    }
    void Start()
    {
        
    }


    public void BuyItem()
    {
        playerInventory.GiveItem(itemIDNumber);
    }
}
