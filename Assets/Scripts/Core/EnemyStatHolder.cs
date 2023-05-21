using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Combat;


namespace SW.Core
{
    public class EnemyStatHolder : MonoBehaviour
    {
        Health health;
        ObjectPooler enemyPool;
        public static EnemyStatHolder Instance;

        private void Awake()
        {
            if (Instance == null) 
            {
                Instance = this;
                DontDestroyOnLoad (gameObject);
                
            } 
            else
            {
                Destroy (gameObject);
            }
        }

        
    }
}

