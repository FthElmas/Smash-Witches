using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Combat;


namespace SW.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        
        [SerializeField]private Slider slider;

        private void Awake()
        {
            
        }
        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
        public void HealthBar(float health)
        {
            slider.value =  health;
        }
    }

}
