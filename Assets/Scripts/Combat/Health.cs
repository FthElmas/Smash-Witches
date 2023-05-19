using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Core;
using SW.UI;



namespace SW.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;
        PlayerScheduler scheduler;
        [SerializeField] private HealthBarUI healthBar;
        

        private void Awake()
        {
            scheduler = GetComponent<PlayerScheduler>();
            
            
        }
        private void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
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

        public float GetHealthPercentage()
        {
            return currentHealth / maxHealth;
        }
        
    }

}
