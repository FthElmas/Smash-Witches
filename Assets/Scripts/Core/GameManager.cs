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
        [SerializeField]private TMPro.TextMeshProUGUI roundNumberText;
        private int roundNumber = 1;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            health = player.GetComponent<Health>();
            poolObject = GameObject.FindWithTag("EnemyPool");
            enemyPool = poolObject.GetComponent<ObjectPooler>();
        }
        private void Update()
        {
            
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
            
            if(enemyPool.AreEnemiesDead())
            {
                roundNumberText.text = roundNumber.ToString();
                roundNumber++;
                SceneManager.LoadScene(1);
            }
            
        }

    }

}
