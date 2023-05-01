using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsEast : MonoBehaviour
{
    float xPos;
    float yPos;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Main Plane")) {
            Debug.Log("Triggered: " + collider.transform.name);
            //Vector2 planePosition = collider.transform.position;
            Vector3 colliderAngles = collider.transform.eulerAngles;
            Vector3 newRotation = new Vector3(colliderAngles.x, colliderAngles.y, 
                                             (colliderAngles.z * -1) + colliderAngles.z);
            collider.transform.eulerAngles = newRotation;
        }
    }
}
