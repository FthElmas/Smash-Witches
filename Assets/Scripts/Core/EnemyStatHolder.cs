using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Combat;


namespace SW.Core
{
    public class EnemyStatHolder : MonoBehaviour
    {
       
        private static EnemyStatHolder _instance;
        public static EnemyStatHolder Instance {get{return _instance;}}
        [SerializeField] private EnemyStatSO enemyStat;
        public EnemyStatSO EnemyStat {get{return enemyStat;}}

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

        public void IncreaseSpeed(float speed)
        {
            EnemyStat.Speed += speed;
        }
        public void IncreaseWeaponDamage(float weaponDamage)
        {
            EnemyStat.WeaponDamage += weaponDamage;
        }
        public void IncreaseEnemy(int number)
        {
            EnemyStat.EnemyNumber = number;
        }

        
    }
}

