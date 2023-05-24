using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using SW.Combat;
using SW.Shop;


namespace SW.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField]private float chaseDistance;
        [SerializeField] private float deathTime = 2f;
        public Action<GameObject> attackBehaviour;
        GameObject player;
        EnemyHealth target;
        Attacker  fighter;
        Coin _coin;
        
        
        
        

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Attacker>();
            
            target = GetComponent<EnemyHealth>();
        }

        private void Start()
        {
            _coin = Coin.FindAnyObjectByType<Coin>();
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
            attackBehaviour?.Invoke(player);
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
                DropCoin();
                yield return new WaitForSeconds(deathTime);
                Destroy(gameObject);
            }
        }

        private void DropCoin()
        {
            int drop = UnityEngine.Random.Range(5,15);
            _coin.AddCoinDrop(drop);
            
        }
    }


}
