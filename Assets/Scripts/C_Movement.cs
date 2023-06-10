using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Movement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D target;
    [HideInInspector] public Rigidbody2D rb;

    [HideInInspector] public Vector3 targetPosition;
    [HideInInspector] public Vector3 selfPosition;
    [HideInInspector] public Vector2 targetVelocity;

    float _deviationAmount = 50;


    public void MoveInterceptionPlane(Rigidbody2D rb, Vector3 targetPosition, 
                    Vector3 selfPosition, Vector2 targetVelocity, float projectileSpeed, 
                    float planeSpeed)
    {
        if (Math.InterceptionDirection(a: targetPosition, b: selfPosition, vA: targetVelocity, projectileSpeed, result: out var direction))
        {
            rb.velocity = direction * planeSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.Rotate(180, 0, -angle);
        } else
        {
            rb.velocity = (targetPosition - selfPosition).normalized * planeSpeed;
        }
    }
    public void MoveRocketPlane(Rigidbody2D rb, float planeSpeed)
    {
        rb.velocity = transform.right * planeSpeed;
    }
    public void MoveMainPlane(float movX, float movY, float acceleration, float rotationControl, float speed)
    {
        Vector2 Vel = transform.right * (movX * acceleration);
        rb.AddForce(Vel);

        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(acceleration > 0)
        {
            if(Dir > 0)
            {
                rb.rotation += movY * rotationControl * (rb.velocity.magnitude / speed); 
            }
            else
            {
                rb.rotation -= movY * rotationControl * (rb.velocity.magnitude / speed); 
            }
        }
        float thrustforce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustforce;

        rb.AddForce(rb.GetRelativeVector(relForce));


        if(rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
}
