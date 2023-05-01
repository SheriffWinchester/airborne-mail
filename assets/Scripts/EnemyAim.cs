using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public GameObject target;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float speed = 3f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane");
        // Calculate the distance between the enemy and the target
        float distance = Vector2.Distance(transform.position, target.transform.position);

        // Calculate the time it will take for the projectile to reach the predicted position
        float timeToTarget = distance / projectileSpeed;

        // Predict the future position of the target based on its current velocity
        Vector2 predictedPosition = target.transform.position + (target.GetComponent<Rigidbody2D>().velocity * timeToTarget);

        // Aim at the predicted position
        transform.LookAt(predictedPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        //projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * transform.forward;
        transform.position = Vector2.MoveTowards(transform.position, predictedPosition);
        //rb.velocity = projectileSpeed * transform.forward;
    }
}
