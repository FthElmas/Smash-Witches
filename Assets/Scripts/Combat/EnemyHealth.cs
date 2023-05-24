using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.UI;
using SW.Core;

namespace SW.Combat
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        private float maxHealth;
        private float currentHealth;
        PlayerScheduler scheduler;
        [SerializeField] private HealthBarUI healthBar;
        

        private void Awake()
        {
            scheduler = GetComponent<PlayerScheduler>();
            
            
        }
        private void Start()
        {
            maxHealth = EnemyStatHolder.Instance.EnemyStat.MaxHealth;
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

        public float GetHealthPercentage()
        {
            return currentHealth / maxHealth;
        }

    }

}
