using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10f;          
    public float rotationSpeed = 100f;    
    private float verticalInput;   
  
    void FixedUpdate()
    {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

       
        verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            transform.Rotate(Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);
        }
    }
}