using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Combat;
using SW.Core;
using SW.Interface;


namespace SW.UI
{
    public class Skill2CoolDown : MonoBehaviour
    {
        PlayerCombat combat;
        Image coolDownImage;
        private float skill2CoolDownTime;
        private float skill2CoolDownTimer = 0.0f;

        private void Start()
        {
            coolDownImage = GetComponent<Image>();
            skill2CoolDownTime = StatHolderSingleton.Instance.StatData.Skill2Cooldown;
            combat = PlayerCombat.FindAnyObjectByType<PlayerCombat>();
            coolDownImage.fillAmount = 0;
        }

        private void LateUpdate()
        {
           if(!combat.GetSkill2())
            {
                CoolDownUI();
            }   
        }

        public void CoolDownUI()
        {
            skill2CoolDownTimer -= Time.deltaTime;
            
            if(skill2CoolDownTimer < 0.0f)
            {
                coolDownImage.fillAmount = 0;
                skill2CoolDownTimer = skill2CoolDownTime;
            }
            else
            {
                coolDownImage.fillAmount = skill2CoolDownTimer / skill2CoolDownTime;
                
            }
        }
    }

}
