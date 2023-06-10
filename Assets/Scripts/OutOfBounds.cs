using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    float xPos;
    float yPos;
    void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Main Plane"))
        {
            InversePosition(collider);
        } 
        if (collider.CompareTag("Fighter Plane"))
        {
            DestroyObject(collider);
        }
        if (collider.CompareTag("Rocket Plane"))
        {
            DestroyObject(collider);
        }
        if (collider.CompareTag("Missile"))
        {
            DestroyObject(collider);
        }
    }
    public void DestroyObject(Collider2D collider)
    {
        Debug.Log("Triggered: " + collider.transform.name);
        Destroy(collider.gameObject);
        collider = null;
    }
    public void InversePosition(Collider2D collider)
    {
        Debug.Log("Triggered: " + collider.transform.name);
        //Vector2 planePosition = collider.transform.position;
        xPos = collider.transform.position.x;
        yPos = collider.transform.position.y;
        collider.transform.position = new Vector2(xPos, (yPos * 0) - yPos);
        collider = null;
    }
}
