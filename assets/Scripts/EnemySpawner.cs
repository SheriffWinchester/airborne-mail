using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Camera mainCamera;
    GameObject spawnPlane;
    [SerializeField] GameObject[] prefabs;

    float spawnX;
    float forceAngleX;
    float forceAngleY;
    float forceSpeed;
    float spawnWait;
    int prefabRandom;

    void Start()
    {
        StartCoroutine(SpawnPlanes());
    }

    void Update() {
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector2 ray = mainCamera.ScreenToWorldPoint(spawnCoordinate); 
        //     Debug.Log(ray);
        // }
        
    }

    IEnumerator SpawnPlanes() {
        while(true) {
            spawnX = Random.Range(-5.0f, -1.0f);
            forceAngleX = Random.Range(4.0f, -2.5f);
            forceAngleY = Random.Range(4.0f, -4.0f);
            forceSpeed = Random.Range(-20f, -40f);
            spawnWait = Random.Range(1.0f, 3.5f);
            prefabRandom = Random.Range(0, 4);

            Vector2 forceAngle = new Vector2(forceAngleX, forceAngleY);
            Vector2 forceVertical = new Vector2(forceAngleX, 5.0f);

            spawnPlane = Instantiate(prefabs[prefabRandom], new Vector3(spawnX, 5.5f, 0.0f), Quaternion.identity);
            spawnPlane.GetComponent<Rigidbody2D>().AddForce(forceVertical * forceSpeed);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}