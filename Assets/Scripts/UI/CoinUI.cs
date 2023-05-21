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
        [SerializeField]private Coin coinComponent;
        private int currentCoin;

        private void Awake()
        {
            currentCoin = coinComponent.GetCurrentCoin();
            currentCoinText = Text.FindFirstObjectByType<Text>();
        }

        private void Update()
        {
            UpdateCoinUI();
        }

        private void UpdateCoinUI()
        {
            currentCoinText.text = currentCoin.ToString();
        }
    }

}
