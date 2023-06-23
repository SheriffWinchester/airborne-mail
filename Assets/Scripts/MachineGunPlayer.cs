using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGunPlayer : C_PlaneWeapons
{
    public Rigidbody2D bulletPrefab;
    public float projectileSpeed = 10.0f; 
    public float fireRate = 50f;
    float fireRateX;
    float nextFire;
    void Update() 
    {
        // Debug.Log("NF: " + nextFire);
        // Debug.Log("TT: " + Time.time);
        //Debug.Log("1515: " + nextFire);
        Debug.Log("NF: " + nextFire);
        fireRateX = fireRate / 100;
        _MachineGunPlayer(Time.time, ref nextFire, fireRateX, projectileSpeed, 
                                bulletPrefab);
    }
}