using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGunPlayer : C_PlaneWeapons
{
    public Rigidbody2D bulletPrefab;
    public float projectileSpeed = 10.0f; 

    public float fireRate = 0.5f;
    public float nextFire;
    float time;
    void Awake() 
    {
        time = Time.time;
    }
    void Start() 
    {
        QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 25;
    }
    void Update() 
    {
        // Debug.Log("NF: " + nextFire);
        // Debug.Log("TT: " + Time.time);
        // if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        // {
        //     nextFire = Time.time + fireRate;
        //     if(Time.timeScale != 0f)
        //     {
        //         var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //         bullet.velocity = transform.right * projectileSpeed;
        //     }
            
        // }
        //Debug.Log("1515: " + nextFire);
        Debug.Log("NF: " + nextFire);
        _MachineGunPlayer1(Time.time, nextFire, fireRate, projectileSpeed, 
                                bulletPrefab);
    }
    public float _MachineGunPlayer1(float time, float nextFire, float fireRate, float projectileSpeed, 
                                Rigidbody2D bulletPrefab)
    {
        
        Debug.Log("TT: " + time);
        if (Input.GetKeyDown(KeyCode.Space) && time > nextFire)
        {
            nextFire = time + fireRate;
            if(Time.timeScale != 0f)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.velocity = transform.right * projectileSpeed;
            }
            
        }
        Debug.Log("1515: " + nextFire);
        return nextFire;
    }
}