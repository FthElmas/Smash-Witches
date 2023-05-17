using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Core;



namespace SW.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float health = 100f;
        private float maxHealth = 100f;
        PlayerScheduler scheduler;

        private void Awake()
        {
            scheduler = GetComponent<PlayerScheduler>();
            
            
        }
        public void DamageIntake(float damage)
        {
            health = Mathf.Max(health - damage, 0);
        }

        public bool isDead()
        {
            return health == 0;
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

        public float HealthPercentage()
        {
            return health / maxHealth;
        }
    }

}
