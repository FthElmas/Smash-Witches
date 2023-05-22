using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SW.Shop
{
    public class Coin : MonoBehaviour
    {
        public static Coin Instance;

        void Awake ()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (gameObject);
            } else {
                Destroy (gameObject);
            }
        }

        public int currentCoin;
        [SerializeField] Text[] allCoinsUIText;


        private void Start()
        {
            UpdateAllCoinsUIText();
        }
        public void AddCoinDrop(int coin)
        {
            this.currentCoin += coin;

        }

        public void DecreaseCoin(int price)
        {
            this.currentCoin -= price;
        }

        public bool HasEnoughCoins(int price)
        {
            return (currentCoin >= price);
        }

        public void UpdateAllCoinsUIText ()
	    {
            for (int i = 0; i < allCoinsUIText.Length; i++) {
                allCoinsUIText [i].text = currentCoin.ToString ();
            }
	    }

        public int GetCurrentCoin()
        {
            return currentCoin;
        }
        


    }

}
