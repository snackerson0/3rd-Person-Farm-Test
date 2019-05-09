using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    [SerializeField] private Inventory inventory; 
    void Awake()
    {
        selectedItem = GameObject.Find("Selected Item").GetComponent<UIItem>();

        spriteImage = GetComponent<Image>();

        UpdateItemSlot(null);

        
    }

    void Update()
    {
     
       
    }

    public void UpdateItemSlot(Item item)
    {
        this.item = item;

        if (item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

   
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {

            if (selectedItem.item != null)
            {
                
                Item clone = new Item(selectedItem.item);
                selectedItem.UpdateItemSlot(this.item);
                UpdateItemSlot(clone);
                
                
            }
            else
            {
                
                selectedItem.UpdateItemSlot(this.item);
                UpdateItemSlot(null);
                
                
            }

        }
        else if (selectedItem.item != null && Input.GetMouseButtonDown(1))
        {
            UpdateItemSlot(selectedItem.item);
            
            selectedItem.UpdateItemSlot(null);
            
            
        }
        else if (selectedItem.item != null)
        {
            UpdateItemSlot(selectedItem.item);
            selectedItem.UpdateItemSlot(null);


        }
    }
}
