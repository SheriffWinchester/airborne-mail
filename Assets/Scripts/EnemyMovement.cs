using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : C_Movement
{
    public float projectileSpeed;
    public float planeSpeed;
    void Start() 
    {
        rb.GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();
        
        targetPosition = target.transform.position;
        selfPosition = transform.position;
        targetVelocity = target.velocity;

        MoveInterceptionPlane(rb, targetPosition, selfPosition, targetVelocity, 
                        projectileSpeed, planeSpeed);
    }
}
