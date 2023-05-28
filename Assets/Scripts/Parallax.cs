using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    //public float depth = 1;
    public float speed = 3;

    Rigidbody2D player;

    private void Awake()
    {
        player = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float realVelocity = player.velocity.x / depth;
        // Vector2 pos = transform.position;

        // pos.x -= realVelocity * Time.fixedDeltaTime;

        transform.position -= transform.right * speed * Time.deltaTime;
        Vector2 pos = transform.position;
        if (pos.x <= -15)
            pos.x = 15;
        transform.position = pos;
    }
}