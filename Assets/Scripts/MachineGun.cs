using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGun : PlaneWeapons
{
    public Rigidbody2D projectile;
    public float projectileSpeed = 3f;
    public float rateFire = 0.5f;
    Vector3 targetPosition;
    Vector3 selfPosition;
    Vector2 targetVelocity;
    public Rigidbody2D target;
    public Rigidbody2D rb;
    void Start() 
    {
        rb.GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();
        targetPosition = target.transform.position;
        selfPosition = transform.position;
        targetVelocity = target.velocity;

        StartCoroutine(_MachineGun(projectile, targetPosition, selfPosition, targetVelocity, 
                        projectileSpeed, rateFire));
    }
    // void Update()
    // {
    //     _MachineGun();
    // }
}