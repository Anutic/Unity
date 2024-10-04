using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float forceRock; 
    public float destroyTime = 5f; 
    public LayerMask groundLayer;

   
    public GameObject explosionEffect; 

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); 
        Vector3 force = transform.up * forceRock;
        rb.AddForce(force); 
    }

    void Update()
    {
        DestroyWithTimer(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket")) 
        {
            Explode(); 
            Destroy(gameObject); 
        }
    }

    void Explode()
    {
        Vector3 explosionPosition = transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            explosionPosition = hit.point; 
        }
        
        GameObject explosion = Instantiate(explosionEffect, explosionPosition, transform.rotation);

        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }

    void DestroyWithTimer()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}