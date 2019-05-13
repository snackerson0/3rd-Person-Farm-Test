using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    [SerializeField] public GameObject seedToCreate;
    private Inventory playersInventory;

    private void Awake()
    {
        playersInventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        PlantAndHarvestCrops();
        IsSoilPlowed();
    }


    void PlantAndHarvestCrops()
    {
        Vector3 bellowPlayer = transform.TransformDirection(Vector3.down);
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // probably null reffing because the first thing hit is a baby plant not the grid. Probably have to add raycast mask
            if (Physics.Raycast(transform.position, bellowPlayer, out hitInfo, Mathf.Infinity) )
            {
                GridElement tempGridElement = hitInfo.transform.GetComponent<GridElement>();
                if (tempGridElement.isPlowed && !tempGridElement.hasPlantedCrop)
                {
                    
                    Instantiate(seedToCreate, hitInfo.transform);
                    tempGridElement.hasPlantedCrop = true;
                }
                else print("Soil may not be plowed press E to plow or a crop is already planted");


               /*if(tempGridElement.isPlowed && tempGridElement.hasPlantedCrop)
                {
                    HarvestCrop(tempGridElement);
                }
                */
            }

        }
    }

    bool IsSoilPlowed()
    {
        Vector3 bellowPlayer = transform.TransformDirection(Vector3.down);
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, bellowPlayer, out hitInfo, Mathf.Infinity))
            {
                GridElement tempElement = hitInfo.transform.GetComponent<GridElement>();
                if (!tempElement)
                {
                    print("No grid element found");
                    return false;
                }

                if (!tempElement.isPlowed)
                {
                    tempElement.isPlowed = true;
                    return true;
                }
                else print("already plowed.");
            }

        }

        return false;
    }

    public void NewSeedToUse(GameObject newSeed)
    {
        if (newSeed != null)
        {
            seedToCreate = newSeed;
        }
    }

    private void HarvestCrop(GridElement tempGridElement)
    {
        
        SeedGrowth currentPlantGrowth = tempGridElement.transform.GetComponentInChildren<SeedGrowth>();
        GameObject currentCrop = currentPlantGrowth.gameObject;

        if (currentPlantGrowth != null)
        {
            if (currentPlantGrowth.isPlantFullyGrown)
            {
                print("The crop has been deleted");
                Destroy(currentCrop);
                tempGridElement.hasPlantedCrop = false;
                currentPlantGrowth.isPlantFullyGrown = false; 
                playersInventory.AddItem(currentPlantGrowth.plantItemID);
                currentPlantGrowth = null;
                currentCrop = null;
            }
        }
    }
}


