using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SW.Shop;


namespace SW.Core
{
    public class MenuManager : MonoBehaviour
    {
        SceneOrderSingleton counter;
        Coin _coin;

        private void Awake()
        {
            _coin = Coin.FindAnyObjectByType<Coin>();
            counter = SceneOrderSingleton.FindAnyObjectByType<SceneOrderSingleton>();
        }


        private void Start()
        {
            if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                _coin.ResetCoin();
                counter.ResetCounter();
            }
        }
    }
}
