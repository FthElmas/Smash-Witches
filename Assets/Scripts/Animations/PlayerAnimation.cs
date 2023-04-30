using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
<<<<<<< Updated upstream
using SW.Combat;
using UnityEngine.UI;
using System;
=======

>>>>>>> Stashed changes
namespace SW.Anim
{
    public class PlayerAnimation : MonoBehaviour
    {
        Animator _anim;
<<<<<<< Updated upstream
        Rigidbody rigidb;
        NavMeshAgent navMesh;
        FloatingJoystick fJoy;
        Health healthComponent;
        [SerializeField] private Button basicAttack;
        Health target;
        [SerializeField] private float reloadTime = 2f;
        [SerializeField] private float skillCoolDown = 1f;
        
        
        
        private bool canFire = true;
        private bool canUseSkill = true;
        private bool animCheck = false;
        private float _movementSpeed;
=======
        
        NavMeshAgent navMesh;
        
>>>>>>> Stashed changes

        private void Awake()
        {
            _anim = GetComponent<Animator>();
<<<<<<< Updated upstream
            rigidb = GetComponent<Rigidbody>();
            navMesh = GetComponent<NavMeshAgent>();
            healthComponent = GetComponent<Health>();
            
            
        }

        private void Start()
        {
            GetComponent<PlayerCombat>().basicAnimAction += AttackAnimation;
        }

        
        private void Update()
        {
            if(healthComponent.isDead())
            {
                DeathAnimation();
            }
=======
            navMesh = GetComponent<NavMeshAgent>();
            
        }

        private void Update()
        {
>>>>>>> Stashed changes
            WalkAnimation();
        }

        private void WalkAnimation()
        {
<<<<<<< Updated upstream
            
        _movementSpeed = Input.GetKey(KeyCode.LeftShift) ? 15 : 10;

        var localVelocity = Quaternion.Inverse(transform.rotation) * (rigidb.velocity / _movementSpeed);

       
        _anim.SetFloat("Y", localVelocity.y, 1, Time.deltaTime * 10);
        
        
        _anim.SetFloat("Z", Mathf.Clamp(localVelocity.z, 0, 2), 0.1f, Time.deltaTime * 100);

        

            
        
        }

        IEnumerator ReloadArrow()
        {
            yield return new WaitForSeconds(reloadTime);


            canFire = true;
        }
        IEnumerator SkillCooldown()
        {
            yield return new WaitForSeconds(skillCoolDown);

            canUseSkill = true;
        }
        public void AttackAnimation()
        {
            if(canFire)
            {
                _anim.SetTrigger("attack");
                canFire = false;
                StartCoroutine(ReloadArrow());
                
            }
        }

        

        public void SkillAnimation()
        {
            if(canUseSkill)
            {
                _anim.SetTrigger("skill1");
                canUseSkill = false;
                StartCoroutine(SkillCooldown());
            }
        }

        private void DeathAnimation()
        {
            if(animCheck) return;
        
            animCheck = true;
            _anim.SetTrigger("die");
=======
        Vector3 velocity = navMesh.velocity;
        
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        _anim.SetFloat("forwardSpeed", speed);
>>>>>>> Stashed changes
        }
    }

}
