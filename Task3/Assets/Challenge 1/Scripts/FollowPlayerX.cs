using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane; 
    private Vector3 offset; 

    void Start()
    {
        offset = new Vector3(20f, 2f, -5f);
    }

    void LateUpdate() 
    {
        transform.position = plane.transform.position + offset;

        transform.LookAt(plane.transform.position);
    }
}
