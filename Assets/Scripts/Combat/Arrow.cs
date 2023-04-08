using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SW.Combat
{
public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidBody;

    GameObject enemyTag;
    Health health;

    private bool didHit;
    [SerializeField] private float destroyDelay;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        enemyTag = GameObject.FindWithTag("Enemy");
        
    }
    

    public void Fly(Vector3 force)
    {
        
        rigidBody.AddForce(force, ForceMode.Impulse);
  
    }

    

    void OnCollisionEnter(Collision collision) 
    {
        
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.DamageIntake(damage);
            }
            Destroy(gameObject);

        }
        Destroy(gameObject, destroyDelay);
        rigidBody.velocity = Vector3.zero;

    }

    }

}
