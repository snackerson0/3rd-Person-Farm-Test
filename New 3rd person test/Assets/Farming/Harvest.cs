using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : MonoBehaviour
{
    private Inventory playersInventory;

    [SerializeField] private int cropItemID;

    private GridElement currentGridElement;

    SeedGrowth seedGrowth;


    private void Start()
    {
        currentGridElement = GetComponentInParent<GridElement>();
        seedGrowth = GetComponent<SeedGrowth>();

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playersInventory = other.gameObject.GetComponent<Inventory>();

            if (Input.GetKeyDown(KeyCode.F) && playersInventory != null && seedGrowth.isPlantFullyGrown)
            {
                print("The crop has been deleted");
                Destroy(gameObject);
                playersInventory.AddItem(cropItemID);
                
                if(currentGridElement != null)
                {
                    currentGridElement.hasPlantedCrop = false;
                }
                else
                {
                    print(gameObject.name + "cannot find the grid it is attached to.");
                }
            }
        }
    }
}
