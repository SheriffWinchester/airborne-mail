using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public Camera mainCamera;
    public GameObject spawnPlane;
    public GameObject target;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    //[SerializeField] GameObject[] prefabs;

    float spawnY;
    float forceAngleX;
    float forceAngleY;
    float forceSpeed;
    float spawnWait;
    int prefabRandom;
    public float speed = 3f;

    void Start()
    {
        StartCoroutine(SpawnPlanes());
    }

    void Update() {
        // // Calculate the distance between the enemy and the target
        // float distance = Vector3.Distance(transform.position, target.transform.position);

        // // Calculate the time it will take for the projectile to reach the predicted position
        // float timeToTarget = distance / projectileSpeed;

        // // Predict the future position of the target based on its current velocity
        // Vector3 predictedPosition = target.transform.position + (target.GetComponent<Rigidbody>().velocity * timeToTarget);

        // // Aim at the predicted position
        // transform.LookAt(predictedPosition);
        
    }

    IEnumerator SpawnPlanes() {
        while(true) {
            spawnY = Random.Range(4.0f, -4.0f);
            forceAngleX = Random.Range(4.0f, -4.0f);
            forceAngleY = Random.Range(4.0f, -4.0f);
            forceSpeed = Random.Range(-20f, -40f);
            spawnWait = Random.Range(1.0f, 3.5f);
            prefabRandom = Random.Range(0, 4);

            Vector2 forceAngle = new Vector2(forceAngleX, forceAngleY);
            Vector2 forceVertical = new Vector2(forceAngleX, 4.0f);

            spawnPlane = Instantiate(spawnPlane, new Vector3(9.5f, spawnY, 0.0f), Quaternion.identity);
            //spawnPlane.GetComponent<Rigidbody2D>().AddForce(forceVertical * forceSpeed);
            spawnPlane.transform.position -= transform.right * speed * Time.deltaTime;

            yield return new WaitForSeconds(spawnWait);
        }
    }
}