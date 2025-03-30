using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileMove : MonoBehaviour
{
    public float speed;
    private Vector3 moveDirection;

    // Method to set the initial direction of the projectile
    public void SetTargetPosition(Vector3 target)
    {
        moveDirection = (target - transform.position).normalized;  // Calculate direction to the target
    }

    void Update()
    {
        // Keep moving in the same direction indefinitely
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}