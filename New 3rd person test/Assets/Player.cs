using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController characterController;


    //floats
    [SerializeField] private float characterSpeed = 3.5f;
    private float gravity = 9.81f;


    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();

    }

    private void ProcessMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 velocity = direction * characterSpeed;

        velocity.y -= gravity; // applies gravity.

        characterController.Move(velocity * Time.deltaTime);

    }
}

