using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SW.Combat;
using UnityEngine.UI;



namespace SW.Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        Health health;
        GameObject poolObject;
        GameObject player;
        ObjectPooler enemyPool;
        private int sceneCounter = 1;
        private bool canLoad =true;

        

        public static GameManager Instance;
        
           
        
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
        
        private void Update()
        {
            player = GameObject.FindWithTag("Player");
            health = player.GetComponent<Health>();
            
            if(health.isDead() == true)
            {
                StartCoroutine(LoadingGameOver());
            }
            
            Round();
            
            
        }

        IEnumerator LoadingGameOver()
        {
            
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void Round()
        {
            poolObject = GameObject.FindWithTag("EnemyPool");
            enemyPool = poolObject.GetComponent<ObjectPooler>();
            if(enemyPool.AreEnemiesDead() && canLoad)
            {
                SceneManager.LoadScene(1);
                canLoad = false;
                sceneCounter++;
                
                
            }
            if(!enemyPool.AreEnemiesDead())
            {
                canLoad = true;
            }
            
            
            
            
        }

        

    }

}
