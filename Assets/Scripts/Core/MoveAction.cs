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
    Health health;
    Collider collide;

    private void Awake()
    {   
        health = GetComponent<Health>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        collide = GetComponent<Collider>();
        
    }

   

    private void Start()
    {
        
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
