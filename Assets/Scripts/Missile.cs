using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 3f;
    Rigidbody2D rb;
    GameObject target;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane");
    }
    void Update() {
        FollowTarget();
    }
    void FollowTarget() {
        Vector2 vectorToTarget = transform.position - target.transform.position;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.velocity = -transform.right * speed;
        //Debug.Log(targetRotation);
        // float angle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
        // instance.transform.Rotate(180, 0, -angle);
    }
}
