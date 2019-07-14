using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItems : MonoBehaviour
{
    public Item item;
    private Image spriteImage;

    void Awake()
    {
        spriteImage = GetComponent<Image>();

        UpdateItem(null);
    }

    public void UpdateItem(Item item)
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
}
