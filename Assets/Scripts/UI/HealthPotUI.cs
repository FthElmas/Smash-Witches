using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Core;


namespace SW.UI
{
    public class HealthPotUI : MonoBehaviour
    {
        private int healthPotNumber;
        private Text healthPotText;
        private StatHolderSingleton statHolder;

        public void Start()
        {
            statHolder = StatHolderSingleton.Instance;
            healthPotText = GetComponent<Text>();
            
        }

        public void Update()
        {
            healthPotNumber = statHolder.GetCurrentPot();
            healthPotText.text = healthPotNumber.ToString();
        }
    }

}
