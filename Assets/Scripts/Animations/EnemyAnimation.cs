using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Combat;
using UnityEngine.AI;

namespace SW.Anim
{
    public class EnemyAnimation : MonoBehaviour
    {
        Animator _anim;
        Rigidbody rigidb;
        NavMeshAgent navMesh;
        FloatingJoystick fJoy;
        Health healthComponent;
        
        Health target;

        private bool animCheck = false;
        float speed;
        [SerializeField] private float weaponRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1f;
        private float timeSinceLastAttack = Mathf.Infinity;
        

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            rigidb = GetComponent<Rigidbody>();
            navMesh = GetComponent<NavMeshAgent>();
            healthComponent = GetComponent<Health>();
            
            
        }

        

        private void Update()
        {
            if(healthComponent.isDead())
            {
                DeathAnimation();
            }
            WalkAnimation();

            AttackAnimation();

            timeSinceLastAttack += Time.deltaTime;
        }

        private void WalkAnimation()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            //Transforming global to local, so the animator can know easily
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
            _anim.SetFloat("forwardSpeed", speed);
        }

        public void Attack(GameObject combatTarget)
        {   
            
            target = combatTarget.GetComponent<Health>();
        
        }

        private void AttackAnimation()
        {
            if (target == null) return;
       
            if(target.isDead()) return;

            if(IsInRange() && timeSinceLastAttack > timeBetweenAttacks)
            {
                _anim.SetTrigger("attack");
                timeSinceLastAttack = 0 ;

            }
        }

        private void DeathAnimation()
        {
            if(animCheck) return;
        
            animCheck = true;
            _anim.SetTrigger("die");
        }

        public bool IsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }
    }

}
