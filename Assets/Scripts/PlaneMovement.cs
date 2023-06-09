using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float Speed;
    public float Acceleration;

    Rigidbody2D rb;

    public float RotationControl;

    float MovY, MovX = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovY = Input.GetAxis("Vertical");  
    }

   
    private void FixedUpdate()
    {
        Vector2 Vel = transform.right * (MovX * Acceleration);
        rb.AddForce(Vel);

        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(Acceleration > 0)
        {
            if(Dir > 0)
            {
                rb.rotation += MovY * RotationControl * (rb.velocity.magnitude / Speed); 
            }
            else
            {
                rb.rotation -= MovY * RotationControl * (rb.velocity.magnitude / Speed); 
            }
        }
        float thrustforce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustforce;

        rb.AddForce(rb.GetRelativeVector(relForce));


        if(rb.velocity.magnitude > Speed)
        {
            rb.velocity = rb.velocity.normalized * Speed;
        }
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlaneController : MonoBehaviour
// {
//     [SerializeField] float rcsThrust = 100f;
//     [SerializeField] float mainThrust = 100f;
//     Rigidbody2D rb;
//     Vector2 move;
//     public float movementForce = 1f;
//     public float speed;
//     public float rotationControl;
//     float verticalInput;
//     Vector2 NewPos;
//     [SerializeField] public Vector2 ObjVelocity;
//     Vector2 PrevPos;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }
//     void Update()
//     {
//         float horizontalInput = Input.GetAxisRaw("Horizontal");
//         verticalInput = Input.GetAxisRaw("Vertical");
        
//         transform.position += transform.right * speed * Time.deltaTime;

//         float rotationThisFrame = rcsThrust * Time.deltaTime;

//         if (Input.GetKey(KeyCode.W))
//         {
            
//             transform.Rotate(Vector3.forward * rotationThisFrame);
//         }
//         if (Input.GetKey(KeyCode.S))
//         {
            
//             transform.Rotate(-Vector3.forward * rotationThisFrame);
//         }


//         NewPos = transform.position;  // each frame track the new position
//         ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
//         PrevPos = NewPos;  // update position for next frame calculation
//         //Debug.Log(ObjVelocity);
//     }
  
// }
