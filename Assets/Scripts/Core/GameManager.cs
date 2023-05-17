using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SW.Combat;


namespace SW.Core
{
    public class GameManager : MonoBehaviour
    {
        Health health;
        ObjectPooler objectPool;
        GameObject player;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player");
            health = player.GetComponent<Health>();
        }
        private void Update()
        {
            
            if(health.isDead() == true)
            {
                StartCoroutine(LoadingGameOver());
            }
        }

        IEnumerator LoadingGameOver()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
