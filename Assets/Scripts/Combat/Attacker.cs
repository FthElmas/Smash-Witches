using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Interface;
using SW.Control;
using SW.Core;



namespace SW.Combat
{
    public class Attacker : MonoBehaviour, IAction, IAttack
    {
    [SerializeField] private float weaponRange = 2f;
    Health target;
    MoveAction move;
    PlayerScheduler action;
    Health targetHealth;

    private float weaponDamage;
    
   
    
    void Awake()
    {
        move = GetComponent<MoveAction>();
        action = GetComponent<PlayerScheduler>();
        targetHealth = GetComponent<Health>();
        GetComponent<AIController>().attackBehaviour += Attack;
    }

    private void Start()
    {
        weaponDamage = EnemyStatHolder.Instance.EnemyStat.WeaponDamage;
    }
    private void Update()
        {
            
            MoveAccording();

            
        }

        public void MoveAccording()
        {
            if (target == null) return;

            

            if (!GetIsInRange())
            {
                move.MoveTo(target.transform.position);
            }
            else
            {
                move.Cancel();
                transform.LookAt(target.transform);
                
            }
        }

        //checks the distance between enemytarget and player
        public bool GetIsInRange()
            {
                return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
            }

    
        // combat mode for the player when player encounters an enemy
        public void Attack(GameObject combatTarget)
            {
                action.StartAction(this);
                target = combatTarget.GetComponent<Health>();
                
            }

        // Hit() is called on the exact impact moment to the target by the animator
        public void Hit()
        {   
            targetHealth.DamageIntake(weaponDamage);
        }
        public bool isInCombat()
        {   
            if(target != null) return false;
            return target == null;
        }
        public void Cancel()
        {
            
            target = null;
        }


        public bool CanAttack(GameObject combatTarget)
        {
            if(combatTarget == null) return false;

            targetHealth = combatTarget.GetComponent<Health>();
            return targetHealth != null && !targetHealth.isDead();


        }
    }

}
