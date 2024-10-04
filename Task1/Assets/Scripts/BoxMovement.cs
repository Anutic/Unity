using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float speed = 1f; 
    public float movementRange = 5f; 
    private Vector3 startPosition;
    private bool isMoving = false; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isMoving)
        {
            float newX = Mathf.PingPong(Time.time * speed, movementRange) - (movementRange / 2f);
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + newX);
        }
    }

    public void EnableMovement(float newSpeed)
    {
        isMoving = true;
        speed = newSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void StopMovement()
    {
        isMoving = false; 
    }
}
