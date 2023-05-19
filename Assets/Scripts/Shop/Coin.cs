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

        public int coin{get; set;}
        [SerializeField] Text[] allCoinsUIText;
        public void AddCoinDrop(int coin)
        {
            this.coin += coin;

        }

        public void DecreaseCoin(int price)
        {
            this.coin -= price;
        }

        public bool HasEnoughCoins(int price)
        {
            return (coin >= price);
        }

        public void UpdateAllCoinsUIText ()
	{
		for (int i = 0; i < allCoinsUIText.Length; i++) {
			allCoinsUIText [i].text = coin.ToString ();
		}
	}

        


    }

}
