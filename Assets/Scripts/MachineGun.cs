using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGun : C_PlaneWeapons
{
    public Rigidbody2D projectile;
    public float projectileSpeed = 3f;
    public float rateFire = 0.5f;
    void Start() 
    {
        target = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();

        targetPosition = target.transform.position;
        selfPosition = transform.position;
        targetVelocity = target.velocity;

        StartCoroutine(_MachineGun(projectile, targetPosition, selfPosition, targetVelocity, 
                        projectileSpeed, rateFire));
    }
}