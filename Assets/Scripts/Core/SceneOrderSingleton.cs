using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SW.Core
{
    public class SceneOrderSingleton : MonoBehaviour
    {
        
        public static SceneOrderSingleton Instance;
        private int sceneCounter = 1;

         public int SceneCounter{get{return sceneCounter;} 
        set{}}
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

        public void IncreaseCounter()
        {
            sceneCounter += 1;
        }

        public void ResetCounter()
        {
            sceneCounter = 1;
        }
    }
}
