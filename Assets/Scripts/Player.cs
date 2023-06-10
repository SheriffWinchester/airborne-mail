using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Bullet"))
        {
            
        }
    }
}