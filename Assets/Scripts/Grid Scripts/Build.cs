using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Build : MonoBehaviour
{
    [SerializeField] GameObject objectToCreate;
    private GameObject currentCreatedBuildable; 
    public GridElement CurSelectedGridElement, curHoveredGridElement, lastHoveredGridElement;

    public GridElement[] grid; 
    [Header("Color")]
    public Color colorOnHover = Color.white;
    public Color colorOnOccupied = Color.red;

    private RaycastHit mouseHit;
    private Color colorOnNormal;

    public bool buildInProgress;

    public Buildings buildings;

	// Use this for initialization
	void Awake ()
	{
	    colorOnNormal = grid[0].GetComponentInChildren<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    ProcessMouseSelectionAndHover();
      //  MoveBuilding();
      //  PlaceBuilding();
	}

    private void ProcessMouseSelectionAndHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out mouseHit))
        {
            GridElement g = mouseHit.transform.GetComponent<GridElement>();
            if (!g)
            {
                if (curHoveredGridElement)
                {
                    
                    curHoveredGridElement.GetComponent<MeshRenderer>().material.color = colorOnNormal;
                    return;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                CurSelectedGridElement = g;

                if (CurSelectedGridElement.isOccupied)
                {
                    print("this grid is already occupied");
                }
                else
                    CreateItem(mouseHit);
            }

            if (g)
            {
                curHoveredGridElement = g;
            }

            if (g = curHoveredGridElement)
            {
                if (!g.isOccupied) mouseHit.transform.GetComponent<MeshRenderer>().material.color = colorOnHover;
                else mouseHit.transform.GetComponent<MeshRenderer>().material.color = colorOnOccupied;
            }

            if (g != curHoveredGridElement)
            {
                curHoveredGridElement = g;
            }

            if (!lastHoveredGridElement)
            {
                lastHoveredGridElement = curHoveredGridElement;
            }

            if (lastHoveredGridElement != curHoveredGridElement)
            {
                lastHoveredGridElement.GetComponent<MeshRenderer>().material.color = colorOnNormal;
                lastHoveredGridElement = curHoveredGridElement;
            }
        }
    }

    private void CreateItem(RaycastHit hit)
    {
        print("The grid was not full and is now full.");
        CurSelectedGridElement.isOccupied = true;

        
        GameObject createdObject = Instantiate(objectToCreate, hit.transform.position, Quaternion.identity);
        //createdObject.transform.SetParent(CurSelectedGridElement.transform, false);

        //GameObject createdItem = CurSelectedGridElement.GetComponentInChildren<Surface>().gameObject;
        //createdItem.transform.localScale = new Vector3(6.21f,16.61f, 6.33f);
    }


}
