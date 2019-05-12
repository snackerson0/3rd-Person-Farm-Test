using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopMenu : MonoBehaviour
{
    // check for collision
    // check if it is the player
    // check if they pressed e key
    //check if they have enough money
    //remove money
    //update inventory
    [SerializeField] private GameObject menu;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //toggles menu on and off based on if it is currently active

                menu.SetActive(!menu.activeSelf);

                /*
                 
                Player currentPlayer = other.GetComponent<Player>();

                if(currentPlayer != null)
                {
                   
                }
                */
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
