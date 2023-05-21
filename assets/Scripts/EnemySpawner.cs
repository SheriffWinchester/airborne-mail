using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public Camera mainCamera;
    //public GameObject color;
    public GameObject spawnPlane;
    //[SerializeField] GameObject[] prefabs;

    float spawnX, spawnY, forceAngleX, forceAngleY;
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
            spawnX = 10f;
            spawnY = Random.Range(3.0f, -3.0f);
            forceAngleX = Random.Range(4.0f, -2.5f);
            forceAngleY = Random.Range(4.0f, -4.0f);
            forceSpeed = Random.Range(-10f, -30f);
            spawnWait = Random.Range(1.0f, 3.5f);
            //prefabRandom = Random.Range(0, 4);

            // Vector2 forceAngle = new Vector2(forceAngleX, forceAngleY);
            // Vector2 forceVertical = new Vector2(forceAngleX, 5.0f);

            Instantiate(spawnPlane, new Vector2(spawnX, spawnY), Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}