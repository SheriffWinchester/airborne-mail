using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGun : PlaneWeapons
{
    public Rigidbody2D projectile;
    public float projectileSpeed = 3f;
    public float rateFire = 0.5f;
    // Vector3 targetPosition;
    // Vector3 selfPosition;
    // Vector2 targetVelocity;
    // public Rigidbody2D target;
    void Start() 
    {
        target = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();

        targetPosition = target.transform.position;
        selfPosition = transform.position;
        targetVelocity = target.velocity;
        Debug.Log(string.Format("{0}, {1}, {2}", targetPosition, selfPosition, targetVelocity));
        StartCoroutine(_MachineGun(projectile, targetPosition, selfPosition, targetVelocity, 
                        projectileSpeed, rateFire));
    }
    // void Update()
    // {
    //     _MachineGun();
    // }
}