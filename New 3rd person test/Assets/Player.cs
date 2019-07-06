using System;
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

    [SerializeField] Toolbar toolbar;

    private float gravity = 9.81f;


    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInventory.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        DisplayInventory();
        UseToolbarItems();
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
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
           Cursor.lockState = CursorLockMode.Locked;

        }

        else if (Input.GetKeyDown(KeyCode.I) && !playerInventory.activeSelf)
        {
            playerInventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void UseToolbarItems()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("button 1 was pressed");
            toolbar.UseToolbarItemSlot(1);   
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("button 2 was pressed");
            toolbar.UseToolbarItemSlot(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("button 3 was pressed");
            toolbar.UseToolbarItemSlot(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("button 4 was pressed");
            toolbar.UseToolbarItemSlot(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            print("button 5 was pressed");
            toolbar.UseToolbarItemSlot(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            print("button 6 was pressed");
            toolbar.UseToolbarItemSlot(6);
        }
    }
}
