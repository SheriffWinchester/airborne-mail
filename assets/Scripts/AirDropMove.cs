using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= transform.right * 3 * Time.deltaTime;
    }
}
