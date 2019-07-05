using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    [SerializeField] public GameObject seedToCreate;

    Crop cropToHarvest;

    private Inventory playersInventory;


    private void Awake()
    {
        playersInventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        PlantAndHarvestCrops();
        PlowSoil();
    }


    void PlantAndHarvestCrops()
    {
        Vector3 belowPlayer = transform.TransformDirection(Vector3.down);
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, belowPlayer, out hitInfo, Mathf.Infinity) )
            {
                GridElement tempGridElement = hitInfo.transform.GetComponent<GridElement>();
                if (tempGridElement != null)
                {
                    if (tempGridElement.isPlowed && !tempGridElement.hasPlantedCrop)
                    {

                        Instantiate(seedToCreate, hitInfo.transform);
                        tempGridElement.hasPlantedCrop = true;
                    }
                    else print("Soil may not be plowed press E to plow or a crop is already planted");

                }
               
            }

        }
    }

    void PlowSoil()
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
                    return;
                }

                if (!tempElement.isPlowed)
                {
                    tempElement.isPlowed = true;
                    return;
                }
                else print("already plowed.");
            }

        }       
    }

    public void NewSeedToUse(GameObject newSeed)
    {
        if (newSeed != null)
        {
            seedToCreate = newSeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crop")
        {
            cropToHarvest = other.gameObject.GetComponent<Crop>();
            if (cropToHarvest == null)
                print("The crop was never given a Crop script");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && playersInventory != null && cropToHarvest != null && cropToHarvest.isPlantGrown && other.tag == "Crop")
            HarvestCrop();

        if (Input.GetKeyDown(KeyCode.Q) && cropToHarvest != null && !cropToHarvest.isPlantGrown && other.tag == "Crop")
            WaterCrop(other);


        if (Input.GetKeyDown(KeyCode.Q) && cropToHarvest != null && cropToHarvest.isPlantGrown && other.tag == "Crop")
            print("You cannot water an already grown plant");
    }

    private void OnTriggerExit(Collider other)
    {
        if (cropToHarvest != null)
            cropToHarvest = null;
    }

    private void HarvestCrop()
    {
        // TODO add a quality meter to obtain from the crop based on player performance.
        if (cropToHarvest.cropName == null)
            print("Name was never given to crop in Crop script");
        
        playersInventory.AddQualityItem(cropToHarvest.cropName,cropToHarvest.cropQuality);


        GridElement currentGridElement = cropToHarvest.GetComponentInParent<GridElement>();

        if (currentGridElement != null)
        {
            currentGridElement.hasPlantedCrop = false;
        }
        else
        {
            print(gameObject.name + "cannot find the grid it is attached to.");
        }
        print("The crop has been deleted");
        Destroy(cropToHarvest.gameObject);

    }

    private void WaterCrop(Collider other)
    {
        Crop currentCrop = other.gameObject.GetComponent<Crop>();

        currentCrop.hasBeenWatered = true;

        print("The Plant has been water");
    }
}


