using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 2.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 tempAngles = transform.localEulerAngles;
        while (tempAngles.x > 180)
        {
            tempAngles.x -= 360;
        }


        



        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        tempAngles.x -= mouseY * mouseSensitivity;

       float mathClamp =  Mathf.Clamp(tempAngles.x, -15.0f, 30.0f);
        
        newRotation.x = mathClamp;
        
        transform.localEulerAngles = newRotation;
        
        
        
        
    }
}
