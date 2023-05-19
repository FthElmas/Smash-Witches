using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using SW.Core;

namespace SW.UI
{
    public class RoundUpdate : MonoBehaviour
    {
        [SerializeField]private TMPro.TextMeshProUGUI roundNumberText;
        private int roundNumber;
        GameManager gameManager;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            roundNumber = GameManager.Instance.SceneCounter;
            roundNumberText = TMPro.TextMeshProUGUI.FindObjectOfType<TMPro.TextMeshProUGUI>();
            
        }
        private void Update()
        {
            UpdateText();
            
        }

        public void UpdateText()
        {
            roundNumberText.text = roundNumber.ToString();
            print(roundNumber.ToString());
        }
    }

}
