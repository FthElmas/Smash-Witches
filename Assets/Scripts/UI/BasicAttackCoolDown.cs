using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Combat;
using SW.Core;
using SW.Interface;


namespace SW.UI
{
    public class BasicAttackCoolDown : MonoBehaviour
    {
        PlayerCombat combat;
        Image coolDownImage;
        private float basicAttackCooldown;
        private float basicAttackCooldownTimer = 0.0f;

        private void Start()
        {
            coolDownImage = GetComponent<Image>();
            basicAttackCooldown = StatHolderSingleton.Instance.StatData.BasicAttackCooldown;
            combat = PlayerCombat.FindAnyObjectByType<PlayerCombat>();
            coolDownImage.fillAmount = 0;
        }

        private void LateUpdate()
        {
           if(!combat.GetBasicAttack())
            {
                CoolDownUI();
            }   
        }

        public void CoolDownUI()
        {
            basicAttackCooldownTimer -= Time.deltaTime;
            
            if(basicAttackCooldownTimer < 0.0f)
            {
                coolDownImage.fillAmount = 0;
                basicAttackCooldownTimer = basicAttackCooldown;
            }
            else
            {
                coolDownImage.fillAmount = basicAttackCooldownTimer / basicAttackCooldown;
                
            }
        }  
    }
}
