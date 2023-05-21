using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SW.Core
{
    public class MenuManager : MonoBehaviour
    {
        SceneOrderSingleton counter;


        private void Awake()
        {
            counter = SceneOrderSingleton.FindAnyObjectByType<SceneOrderSingleton>();
        }


        private void Start()
        {
            if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                counter.ResetCounter();
            }
        }
    }
}
