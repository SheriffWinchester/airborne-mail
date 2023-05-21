using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float projectileSpeed;
    public float planeSpeed;
    public Rigidbody2D target;
    public Rigidbody2D rb;
    public void Start() 
    {
        rb.GetComponent<Rigidbody2D>();
        target = GameObject.Find("Main Plane").GetComponent<Rigidbody2D>();
        MovePlane();
        StartCoroutine(Fire());
        //InvokeRepeating(nameof(Fire), time: 1f, repeatRate: 1f);    
    }
    public void Update()
    {
        
    }
    public void MovePlane()
    {
        
        if (InterceptionDirection(a: target.transform.position, b: transform.position, vA: target.velocity, projectileSpeed, result: out var direction))
        {
            rb.velocity = direction * planeSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, angle);
            //transform.LookAt(direction, Vector3.forward);
        } else
        {
            rb.velocity = (target.transform.position - transform.position).normalized * planeSpeed;
        }
    }
    IEnumerator Fire()
    {
        var instance = Instantiate(projectile, transform.position, rotation: Quaternion.identity);
        if (InterceptionDirection(a: target.transform.position, b: transform.position, vA: target.velocity, projectileSpeed, result: out var direction))
        {
            instance.velocity = direction * projectileSpeed;
        } else
        {
            instance.velocity = (target.transform.position - transform.position).normalized * projectileSpeed;
        }
        yield return new WaitForSeconds(0.5f);
    }
    
    public bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    {
        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;
        if (MyMath.SolveQuadratic(a: 1 - r * r, b: 2 * r * dC * Mathf.Cos(alpha), c: -(dC * dC), out var root1, out var root2) == 0)
        {
            result = Vector2.zero;
            return false;
        }
        var dA = Mathf.Max(a: root1, b: root2);
        var t = dA / sB;
        var c = a + vA * t;
        result = (c - b).normalized;
        return true;
    }

    public class MyMath
    {
        public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
        {
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                root1 = Mathf.Infinity;
                root2 = -root1;
                return 0;
            }

            
            root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
            root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
            return discriminant > 0 ? 2 : 1;
        }
    }
}
