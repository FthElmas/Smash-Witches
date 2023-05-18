using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SW.Combat;
using UnityEngine.UI;
using System;
namespace SW.Anim
{
    public class PlayerAnimation : MonoBehaviour
    {
        Animator _anim;
        Rigidbody rigidb;
        NavMeshAgent navMesh;
        FloatingJoystick fJoy;
        Health healthComponent;
        [SerializeField] private Button basicAttack;
        Health target;
        [SerializeField] private float reloadTime = 2f;
        
        
        public Action skillReset;
        
        private bool canFire = true;
        
        private bool animCheck = false;
        private float _movementSpeed;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            rigidb = GetComponent<Rigidbody>();
            navMesh = GetComponent<NavMeshAgent>();
            healthComponent = GetComponent<Health>();
            
            
        }

        private void Start()
        {
            GetComponent<PlayerCombat>().basicAnimAction += AttackAnimation;
            GetComponent<PlayerCombat>().skill2AnimAction+= Skill2Animation;
        }

        
        private void Update()
        {
            if(healthComponent.isDead())
            {
                DeathAnimation();
            }
            WalkAnimation();
        }

        private void WalkAnimation()
        {
            
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
        
        public void AttackAnimation()
        {
            _anim.SetTrigger("attack");
        }

        

        public void SkillAnimation()
        {
            
            _anim.SetTrigger("skill1");
            
        }

        public void Skill2Animation()
        {
            _anim.SetTrigger("skill2");
        }

        private void DeathAnimation()
        {
            if(animCheck) return;
        
            animCheck = true;
            _anim.SetTrigger("die");
        }
    }

}
