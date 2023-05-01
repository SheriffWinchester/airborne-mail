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
            Debug.Log("Triggered: " + collider.transform.name);
            //Vector2 planePosition = collider.transform.position;
            xPos = collider.transform.position.x;
            yPos = collider.transform.position.y;
            collider.transform.position = new Vector2(xPos, (yPos * 0) - yPos);
        }    
    }
}
