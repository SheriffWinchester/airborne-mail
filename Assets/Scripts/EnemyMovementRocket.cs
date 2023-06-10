using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRocket : C_Movement
{
    public float planeSpeed;
    void Start() 
    {
        rb = transform.GetComponent<Rigidbody2D>();
        transform.Rotate(180, 0, 180);
    }
    void FixedUpdate() {
        MoveRocketPlane(rb, planeSpeed);
    }
}
