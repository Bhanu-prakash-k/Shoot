using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 200f;
    [SerializeField] bool shootForward;

    [Header("Rotation")]
    [SerializeField] float rotationSpeed = 30f;
    [SerializeField] Transform rotationCenter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootForward = true;
        }

        if (shootForward)
            transform.position += transform.TransformDirection(transform.right) * speed * Time.deltaTime;

        if (!shootForward)
            transform.RotateAround(rotationCenter.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

}
