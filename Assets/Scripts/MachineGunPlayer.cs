using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGunPlayer : C_PlaneWeapons
{
    public Rigidbody2D bulletPrefab;
    public float projectileSpeed = 10.0f; 

    public float fireRate = 5.0f;
    float nextFire = 0.0f;
    void Update() 
    {
        _MachineGunPlayer(nextFire, fireRate, projectileSpeed, bulletPrefab);
    }
}