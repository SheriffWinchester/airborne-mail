using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWeapons : MonoBehaviour
{
    Math _math;
    void Awake() 
    {
        _math = GetComponent<Math>();
    }
    public IEnumerator _MachineGun(Rigidbody2D projectile, Vector3 targetPosition, 
                    Vector3 selfPosition, Vector2 targetVelocity, float projectileSpeed,
                    float rateFire)
    {
        while(true)
        {
            var instance = Instantiate(projectile, transform.position, rotation: Quaternion.identity);
            if (_math.InterceptionDirection(a: targetPosition, b: selfPosition, vA: targetVelocity, projectileSpeed, result: out var direction))
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