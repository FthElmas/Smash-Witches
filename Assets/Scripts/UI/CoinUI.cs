using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using SW.Shop;

namespace SW.UI
{

    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private Text currentCoinText;
        private Coin coinComponent;
        private int currentCoin;

        
        public void Start()
        {
            currentCoinText = GetComponent<Text>();
            coinComponent = Coin.Instance;
        }

        public void Update()
        {
            UpdateCoinUI();
        }

        private void UpdateCoinUI()
        {
            currentCoin = coinComponent.GetCurrentCoin();
            currentCoinText.text = currentCoin.ToString();
        }
    }

}
