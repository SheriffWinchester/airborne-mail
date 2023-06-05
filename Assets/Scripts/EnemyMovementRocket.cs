using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRocket : MonoBehaviour
{
    public float planeSpeed;
    public Rigidbody2D rb;
    
    void Start() 
    {
        rb = transform.GetComponent<Rigidbody2D>();
        //transform.Rotate(180, 0, 0);
    }
    void FixedUpdate() {
        rb.velocity = -transform.right * planeSpeed;
    }
}
