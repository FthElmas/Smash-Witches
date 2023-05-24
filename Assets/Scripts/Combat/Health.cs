using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Core;
using SW.UI;



namespace SW.Combat
{
    public class Health : MonoBehaviour, IHealth
    {
        private float maxHealth;
        private float currentHealth;
        PlayerScheduler scheduler;
        [SerializeField] private HealthBarUI healthBar;
        private int currentPot;
        

        private void Awake()
        {
            scheduler = GetComponent<PlayerScheduler>();
            
            
        }
        private void Start()
        {
            currentPot = StatHolderSingleton.Instance.StatData.HealthPotNumber;
            maxHealth = StatHolderSingleton.Instance.StatData.MaxHealth;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(currentHealth);
        }
        public void DamageIntake(float damage)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            healthBar.HealthBar(currentHealth);
        }

        public bool isDead()
        {
            return currentHealth == 0;
        }

        public bool isStopFighting()
        {
            if(isDead())
            {
                scheduler.CancelCurrentAction();
                return true;
            }
            return false;
        }


        public void HealthPot(float health)
        {
            if(currentPot > 0)
            {
                this.currentHealth +=health;
                currentPot--;
            }
        }

       
        
    }

}
