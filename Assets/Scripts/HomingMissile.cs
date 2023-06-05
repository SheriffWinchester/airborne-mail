using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rb;
    GameObject target;
    public GameObject missile;
    bool launchedStatus = false;
    GameObject instance;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.Find("Main Plane");
        Invoke("SpawnMissile", 1.5f);
    }
    // void Update() {
    //     // if (launchedStatus == false) 
    //     // {
            
    //     //     SpawnMissile();
    //     //     launchedStatus = true;
    //     // }
    // }
    void SpawnMissile() {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}
