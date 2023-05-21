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
        
        Health health;
        GameObject poolObject;
        GameObject player;
        ObjectPooler enemyPool;
        private int sceneCounter;
        private bool canLoad =true;
        SceneOrderSingleton counter;

        
        
           
        
       

        private void Awake()
        {
            counter = SceneOrderSingleton.FindAnyObjectByType<SceneOrderSingleton>();
            poolObject = GameObject.FindWithTag("EnemyPool");
            enemyPool = poolObject.GetComponent<ObjectPooler>();
            player = GameObject.FindWithTag("Player");
            health = player.GetComponent<Health>();
            
            
        }
        
        private void Start()
        {
            
        }
        private void Update()
        {
 
            Round();

            if(health != null && health.isDead() == true)
            {
                StartCoroutine(LoadingGameOver());
                
            }
            
            
            
        }

        IEnumerator LoadingGameOver()
        {
            
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(2);
            
        }

        private void Round()
        {
            
            
            if(enemyPool.AreEnemiesDead() && canLoad)
            {
                counter.IncreaseCounter();
                SceneManager.LoadScene(1);
                canLoad = false;
                
                
            }
            
            if(!enemyPool.AreEnemiesDead())
            {
                canLoad = true;
            }
            if(SceneManager.GetActiveScene().buildIndex + 1 == 3) return;

            
            
            
            
            
        }

        

    }

}
