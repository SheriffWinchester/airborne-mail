using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : C_PlaneWeapons
{
    public float speed = 3f;
    public float rotationSpeed = 3f;
    public float damage;
    Vector2 vectorToTarget;
    Vector3 rotatedVectorToTarget;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();
    }
    void Update() {
        FireMissile(vectorToTarget, rotatedVectorToTarget, rotationSpeed, speed);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        Damage(collider, collider.name, damage);
    }
}
