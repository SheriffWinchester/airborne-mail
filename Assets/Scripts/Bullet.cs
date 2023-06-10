using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : C_PlaneWeapons
{
    public float damage;
    void OnTriggerEnter2D(Collider2D collider) {
        Damage(collider, collider.name, damage);
    }
    
}