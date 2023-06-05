using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public Camera mainCamera;
    //public GameObject color;
    public GameObject spawnFighterPlane;
    public GameObject spawnRocketPlane;
    //[SerializeField] GameObject[] prefabs;

    float spawnX, spawnY, forceAngleX, forceAngleY;
    float forceSpeed;
    float spawnWait;
    int prefabRandom;

    void Start()
    {
        StartCoroutine(SpawnFighterPlanes());
        StartCoroutine(SpawnRocketPlanes());
    }

    void Update() {
        // if (Input.GetMouseButtonDown(0)) {
        //     Vector2 ray = mainCamera.ScreenToWorldPoint(spawnCoordinate); 
        //     Debug.Log(ray);
        // }
        
    }

    IEnumerator SpawnFighterPlanes() {
        while(true) {
            spawnX = 10f;
            spawnY = Random.Range(3.0f, -3.0f);
            forceAngleX = Random.Range(4.0f, -2.5f);
            forceAngleY = Random.Range(4.0f, -4.0f);
            forceSpeed = Random.Range(-10f, -30f);
            spawnWait = Random.Range(0.5f, 4f);
            //prefabRandom = Random.Range(0, 4);

            Instantiate(spawnFighterPlane, new Vector2(spawnX, spawnY), Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);
        }
    }
    IEnumerator SpawnRocketPlanes() {
        while(true) {
            spawnX = 10f;
            spawnY = Random.Range(3.0f, -3.0f);
            forceAngleX = Random.Range(4.0f, -2.5f);
            forceAngleY = Random.Range(4.0f, -4.0f);
            forceSpeed = Random.Range(-10f, -30f);
            spawnWait = Random.Range(0.5f, 4f);
            //prefabRandom = Random.Range(0, 4);
            var gos = GameObject.FindGameObjectsWithTag("Enemy Plane 2");
            if (gos.Length < 1)
            {
                Instantiate(spawnRocketPlane, new Vector2(spawnX, spawnY), Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnWait);
        }
    }
}