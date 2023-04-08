using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Anim;
using SW.Core;
using SW.Combat;


namespace SW.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]private float chaseDistance;
        [SerializeField] private float deathTime = 2f;

        GameObject player;
        Health target;
        EnemyAnimation _anim;
        Attacker  fighter;
        MoveAction mover;
        PlayerScheduler aiAction;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Attacker>();
            _anim = GetComponent<EnemyAnimation>();
            target = GetComponent<Health>();
        }

        private void Update()
        {
            StartCoroutine(DestroyObjectAfterDeath());
            if(target.isStopFighting()) return;
            
            if(DistanceToPlayer() && fighter.CanAttack(player))
            {
                AttackBehaviour();
            }

            
        }

        private void AttackBehaviour()
        {
            fighter.Attack(player);
            _anim.Attack(player);
            
        }
        



        private bool DistanceToPlayer()
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
                return distanceToPlayer < chaseDistance;
            }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        IEnumerator DestroyObjectAfterDeath()
        {
            
            if(target.isStopFighting())
            {
                yield return new WaitForSeconds(deathTime);
                Destroy(gameObject);
            }
        }
    }


}