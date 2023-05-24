using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Core;


namespace SW.Combat
{
public class Projectile : MonoBehaviour
{
    
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidBody;
    [SerializeField]private GameObject explosionPrefab;
    GameObject enemyTag;
    EnemyHealth health;

    private bool didHit;
    [SerializeField] private float destroyDelay;


    private void Awake()
    {
        damage = StatHolderSingleton.Instance.StatData.Damage;
        rigidBody = GetComponent<Rigidbody>();
        enemyTag = GameObject.FindWithTag("Enemy");
        
    }
    

    public void Fly(Vector3 force)
    {
        
        rigidBody.velocity = force;
  
    }

    

    void OnCollisionEnter(Collision collision) 
    {
        
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health = collision.gameObject.GetComponent<EnemyHealth>();
            if(health != null)
            {
                health.DamageIntake(damage);
            }

        }
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        Destroy(explosion, 1);
        rigidBody.velocity = Vector3.zero;

    }

    public void IncreaseWeaponDamage(float damage)
    {
        this.damage += damage;
    }

    }

}
