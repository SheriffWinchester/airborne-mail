using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlaneWeapons : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPosition;
    [HideInInspector] public Vector3 selfPosition;
    [HideInInspector] public Vector2 targetVelocity;
    [HideInInspector] public Rigidbody2D target;
    [HideInInspector] public Rigidbody2D rb;
    public IEnumerator _MachineGun(Rigidbody2D projectile, Vector3 targetPosition, 
                    Vector3 selfPosition, Vector2 targetVelocity, float projectileSpeed,
                    float rateFire)
    {
        while(true)
        {
            var instance = Instantiate(projectile, transform.position, rotation: Quaternion.identity);
            instance.velocity = transform.right * projectileSpeed;
            yield return new WaitForSeconds(rateFire);
        }
        
    }
    public void FireMissile(Vector2 vectorToTarget, Vector3 rotatedVectorToTarget, float rotationSpeed, float speed) 
    {
        vectorToTarget = transform.position - target.transform.position;
        rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.velocity = -transform.right * speed;
    }
    public void Damage(Collider2D collider, string hitObject, float damage)
    {
        if(collider.CompareTag(hitObject))
        {
            var player = collider.GetComponent<Player>();
            player.health = player.health - damage;
            Destroy(gameObject);
            Debug.Log(player.health);
        }
    }
}