using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SW.Combat;


namespace SW.Core
{
    public class StatHolderSingleton : MonoBehaviour, IStatIncrease
    {
        Health health;
        GameObject player;

        private static StatHolderSingleton Instance;

        private void Awake()
        {

            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }
        }
        
        public void IncreaseDamage()
        {

        }

        public void IncreaseHealth()
        {

        }
    }
}
