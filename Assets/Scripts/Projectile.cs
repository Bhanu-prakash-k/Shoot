using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
             rb.AddForce(transform.forward * speed);
        }
    }

}
