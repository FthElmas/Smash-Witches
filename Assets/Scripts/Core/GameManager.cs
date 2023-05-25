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
        GameObject _ui;
        GameObject shopUI;
        GameObject gameUI;

        
        
           
        
       

        private void Awake()
        {
            
            counter = SceneOrderSingleton.Instance;
            poolObject = GameObject.FindWithTag("EnemyPool");
            enemyPool = poolObject.GetComponent<ObjectPooler>();
            player = GameObject.FindWithTag("Player");
            health = player.GetComponent<Health>();
            
            
        }
        
        private void Start()
        {
            _ui = GameObject.FindWithTag("UI");
            shopUI = _ui.transform.GetChild(1).gameObject;
            gameUI = _ui.transform.GetChild(0).gameObject;


        }
        private void Update()
        {
 
            EnableShopUI();

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

        public void Round()
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

        public void EnableShopUI()
        {
            if(enemyPool.AreEnemiesDead() && canLoad)
            {
                gameUI.SetActive(false);
                shopUI.SetActive(true);
            }
        }

        

    }

}
