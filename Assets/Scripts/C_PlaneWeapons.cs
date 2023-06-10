using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlaneWeapons : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPosition;
    [HideInInspector] public Vector3 selfPosition;
    [HideInInspector] public Vector2 targetVelocity;
    [HideInInspector] public Rigidbody2D target;
    public IEnumerator _MachineGun(Rigidbody2D projectile, Vector3 targetPosition, 
                    Vector3 selfPosition, Vector2 targetVelocity, float projectileSpeed,
                    float rateFire)
    {
        while(true)
        {
            var instance = Instantiate(projectile, transform.position, rotation: Quaternion.identity);
            if (Math.InterceptionDirection(a: targetPosition, b: selfPosition, vA: targetVelocity, projectileSpeed, result: out var direction))
            {
                instance.velocity = direction * projectileSpeed;
            } else
            {
                instance.velocity = (targetPosition - selfPosition).normalized * projectileSpeed;
            }
            yield return new WaitForSeconds(rateFire);
            
        }
        
    }

    // void MachineGun()
    // {
    //     var instance;
    //     instance.velocity = transform.forward * projectileSpeed;
    // }
    // void Missile()
    // {
        
    // }
}