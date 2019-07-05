using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public string cropName;

    public bool isPlantGrown = false, hasBeenWatered = false;

    [SerializeField]private int plantHeight, timeToGrowCrop;
    public int cropQuality;

    BoxCollider collider;
    Vector3 boxColliderSize;


    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
         boxColliderSize = collider.size;
    }


    void Start()
    {
        StartCoroutine(PlantGrowth(timeToGrowCrop));
        transform.localScale = new Vector3(1, 1, 1);


        collider.size = new Vector3(20,20, 20);
    }


    IEnumerator PlantGrowth(float timeToGrow)
    {
        yield return new WaitForSeconds(timeToGrow);
        IncreasePlantSize();

        if (hasBeenWatered)
            cropQuality++;

        isPlantGrown = true;
    }

    private void IncreasePlantSize()
    {
        transform.localScale = new Vector3(1, plantHeight, 1);
        print("Plant has grown");
    }

   
}
