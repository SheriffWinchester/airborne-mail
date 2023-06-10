using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_HomingMissile : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D rb;
    GameObject target;
    public GameObject missile;
    GameObject instance;
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        //target = GameObject.Find("Main Plane");
        Invoke("SpawnMissile", 1.5f);
    }
    void SpawnMissile() {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}
