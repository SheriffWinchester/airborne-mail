using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 3f;
    Rigidbody2D rb;
    GameObject target;
    Vector2 vectorToTarget;
    Vector3 rotatedVectorToTarget;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane");
    }
    void Update() {
        FollowTarget();
    }
    void FollowTarget() {
        vectorToTarget = transform.position - target.transform.position;
        rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.velocity = -transform.right * speed;
    }
}
