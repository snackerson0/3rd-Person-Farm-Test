using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public string cropName;

    public bool isPlantGrown = false;

    [SerializeField]private int plantHeight, timeToGrowCrop;

    void Start()
    {
        StartCoroutine(PlantGrowth(timeToGrowCrop));
        transform.localScale = new Vector3(1, 1, 1);
    }


    IEnumerator PlantGrowth(float timeToGrow)
    {
        yield return new WaitForSeconds(timeToGrow);
        IncreasePlantSize();
        isPlantGrown = true;
    }

    private void IncreasePlantSize()
    {
        transform.localScale = new Vector3(1, plantHeight, 1);
        print("Plant has grown");
    }

   
}
