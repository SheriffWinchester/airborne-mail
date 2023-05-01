using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    Rigidbody2D rb;
    Vector2 move;
    public float movementForce = 1f;
    public float speed;
    public float rotationControl;
    float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        transform.position += transform.right * speed * Time.deltaTime;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        Debug.Log(rb.velocity);

        // Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        // float inputMagnitude = Mathf.Clamp01(movement.magnitude);   
        // transform.Translate(movement * speed * inputMagnitude * Time.deltaTime, Space.World);

        // if (movement != Vector2.zero)
        // {
        //     Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationControl * Time.deltaTime);
        // }

        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

 

        

        // Quaternion targetRotation = Quaternion.LookRotation(movement);
        // targetRotation = Quaternion.RotateTowards(
        //     transform.rotation,
        //     targetRotation,
        //     180 * Time.fixedDeltaTime);
        // rb.MoveRotation(targetRotation);
        // Vector2 Vel = transform.right * (horizontal * movementForce);
        // rb.AddForce(Vel);

        // float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        // if(movementForce > 0)
        // {
        //     if(Dir > 0)
        //     {
        //         rb.rotation += horizontal * rotationControl * (rb.velocity.magnitude / speed);
        //     } 
        //     else
        //     {
        //         rb.rotation -= horizontal * rotationControl * (rb.velocity.magnitude / speed);
        //     }
        // }
        // float thrustforce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        // Vector2 relForce = Vector2.up * thrustforce;

        // rb.AddForce(rb.GetRelativeVector(relForce));


        // if(rb.velocity.magnitude > speed)
        // {
        //     rb.velocity = rb.velocity.normalized * speed;
        // }
        // // rb.velocity = new Vector2(0, 0);
        // // rb.AddRelativeForce(new Vector2(3f * movementForce, 0));
    }

}
