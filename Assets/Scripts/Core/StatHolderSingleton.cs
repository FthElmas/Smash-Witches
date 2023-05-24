using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Combat;


namespace SW.Core
{
    public class StatHolderSingleton : MonoBehaviour, IStatIncrease
    {
        
        [SerializeField] private StatsSO statData;
        
        public StatsSO StatData{get{return statData;}}
        public List<StatsSO> shopItemList;
        
        private static StatHolderSingleton _instance;
        public static StatHolderSingleton Instance{get{return _instance;}}

        private void Awake()
        {

            if (_instance == null) 
            {
                _instance = this;
                DontDestroyOnLoad (gameObject);
            } 
            else 
            {
                Destroy (gameObject);
            }
            
            
        }
        
        public void IncreaseDamage(float damage)
        {
            StatData.Damage += damage;
        }

        public void IncreaseHealth(float health)
        {
            statData.MaxHealth += health;
        }
        public void IncreasePot(int pot)
        {
            statData.HealthPotNumber += pot;
        }
    }
}
