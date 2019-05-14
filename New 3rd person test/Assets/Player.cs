using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField]private GameObject playerInventory;
    //floats
    [SerializeField] private float characterSpeed = 3.5f;

    

    private float gravity = 9.81f;


    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        DisplayInventory();

    }

    private void ProcessMovement()
    {
        
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 velocity = direction * characterSpeed;

        velocity.y -= gravity; // applies gravity.

        // makes the player move to whatever direction is forward.
        Vector3 tempVector = transform.TransformDirection(velocity);

        characterController.Move(tempVector* Time.deltaTime);
        

      
    }

    private void DisplayInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && playerInventory.activeSelf)
        {
            playerInventory.SetActive(false);

        }

        else if (Input.GetKeyDown(KeyCode.I) && !playerInventory.activeSelf)
        {
            playerInventory.SetActive(true);

        }
    }
}
