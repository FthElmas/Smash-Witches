using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SW.Core
{
    public class GameOver : MonoBehaviour
    {
        
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
