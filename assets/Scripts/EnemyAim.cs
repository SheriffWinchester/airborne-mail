using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public GameObject target;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Main Plane");
        // Calculate the distance between the enemy and the target
        float distance = Vector2.Distance(transform.position, target.transform.position);

        // Calculate the time it will take for the projectile to reach the predicted position
        float timeToTarget = distance / projectileSpeed;

        // Predict the future position of the target based on its current velocity
        Vector3 predictedPosition = target.transform.position + (target.GetComponent<Rigidbody>().velocity * timeToTarget);

        // Aim at the predicted position
        transform.LookAt(predictedPosition);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = projectileSpeed * transform.forward;
    }
}
