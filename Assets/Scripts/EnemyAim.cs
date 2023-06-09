using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public GameObject target;
    public GameObject projectilePrefab;
    public Transform playerTransform;
    public Rigidbody2D playerRB;
    Vector2 predictedPosition;
    Vector2 targetPosition;
    Vector2 direction;
    PlaneMovement planeMovement;
    public float projectileSpeed = 10f;
    public float speed = 10f;
    Rigidbody2D rb;
    bool forceOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        
         rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane");
        playerTransform = target.GetComponent<Transform>();
        playerRB = target.GetComponent<Rigidbody2D>();
        planeMovement = target.GetComponent<PlaneMovement>();

        // // Calculate the distance between the enemy and the target
        // float distance = Vector2.Distance(transform.position, target.transform.position);
        // Debug.Log("Distance: " + distance);

        // // Calculate the time it will take for the projectile to reach the predicted position
        // float timeToTarget = distance / speed;
        // targetPosition = target.transform.position;
        // // Predict the future position of the target based on its current velocity
        // predictedPosition = targetPosition + (planeController.ObjVelocity * timeToTarget);

        // // Aim at the predicted position
        // transform.LookAt(predictedPosition);
    }

    // Update is called once per frame
    void Update()
    {
            if (forceOnce)
            {
                Predict();
                Debug.Log(direction);
                forceOnce = false;
            }

        //GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        //projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * transform.forward;
        //transform.position = Vector2.MoveTowards(transform.position, predictedPosition, speed * Time.deltaTime);
        //rb.velocity = projectileSpeed * transform.forward;
        //rb.AddForce(direction);
        //Debug.Log(direction * speed);
    }
    void Predict()
    {
        //targetPosition = target.transform.position;
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        // Calculate the time it will take for the enemy plane to reach the predicted position
        float timeToTarget = distance / speed;

        targetPosition = playerTransform.position;
        // Predict the future position of the player based on their current velocity
        predictedPosition = targetPosition + (playerRB.velocity * timeToTarget);
        transform.position = Vector2.MoveTowards(transform.position, predictedPosition, speed * Time.deltaTime);
        // Calculate the direction to the predicted position
        direction = predictedPosition - (Vector2)transform.position;
        // // Normalize the direction and rotate the enemy plane to face it
        direction.Normalize();
        rb.AddForce(direction * speed);
        //transform.right = direction;
    }
}
