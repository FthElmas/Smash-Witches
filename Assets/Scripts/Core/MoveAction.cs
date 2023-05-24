using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SW.Combat;


namespace SW.Core
{
    public class MoveAction : MonoBehaviour
    {
    
    NavMeshAgent navMeshAgent;
    
    NavMeshHit closestHit;
    EnemyHealth health;
    Collider collide;
    private float speed;

    private void Awake()
    {   
        health = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        collide = GetComponent<Collider>();
        
    }

   

    private void Start()
    {
        speed = EnemyStatHolder.Instance.EnemyStat.Speed;
    }

    private void Update()
    {
        Invoke("EnableNavMeshAgent", 0.025f);

        DisableNavMeshOnDeath();
        DisableColliderOnDeath();
    }
    public void StartMoveAction(Vector3 destination)
            {
                
                MoveTo(destination);
            }
    
    public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = speed;
        }

    public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

    public void DisableNavMeshOnDeath()
        {
            navMeshAgent.enabled = !health.isStopFighting();
        }

    public void DisableColliderOnDeath()
    {
        collide.enabled = !health.isStopFighting();
    }

    private void EnableNavMeshAgent ()
    {
        navMeshAgent.enabled = true;
    }

    
    }


}
