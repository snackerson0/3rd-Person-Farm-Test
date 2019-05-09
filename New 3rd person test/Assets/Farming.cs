using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    [SerializeField] public GameObject seedToCreate;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectUsableSoil();
        IsSoilPlowed();
    }


    void DetectUsableSoil()
    {
        Vector3 bellowPlayer = transform.TransformDirection(Vector3.down);
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(transform.position, bellowPlayer, out hitInfo, Mathf.Infinity) )
            {
                GridElement tempGridElement = hitInfo.transform.GetComponent<GridElement>();
                if (tempGridElement.isPlowed && !tempGridElement.hasPlantedCrop)
                {
                    Instantiate(seedToCreate, hitInfo.transform);
                    tempGridElement.hasPlantedCrop = true;
                }
                else print("Soil may not be plowed press E to plow or a crop is already planted");
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
}


