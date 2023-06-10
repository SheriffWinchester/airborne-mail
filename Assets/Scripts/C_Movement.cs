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
}
