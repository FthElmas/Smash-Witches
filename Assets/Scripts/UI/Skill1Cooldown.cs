using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Combat;
using SW.Core;
using SW.Interface;


namespace SW.UI
{
    public class Skill1Cooldown : MonoBehaviour, ICoolDown
    {
        PlayerCombat combat;
        Image coolDownImage;
        private float skill1CoolDownTime;
        private float skill1CoolDownTimer = 0.0f;

        private void Start()
        {
            coolDownImage = GetComponent<Image>();
            skill1CoolDownTime = StatHolderSingleton.Instance.StatData.Skill1Cooldown;
            combat = PlayerCombat.FindAnyObjectByType<PlayerCombat>();
            coolDownImage.fillAmount = 0;
        }

        private void LateUpdate()
        {
           if(!combat.GetSkill1())
            {
                CoolDownUI();
            }   
        }

        public void CoolDownUI()
        {
            skill1CoolDownTimer -= Time.deltaTime;
            
            if(skill1CoolDownTimer < 0.0f)
            {
                coolDownImage.fillAmount = 0;
                skill1CoolDownTimer = skill1CoolDownTime;
            }
            else
            {
                coolDownImage.fillAmount = skill1CoolDownTimer / skill1CoolDownTime;
                
            }
        }
    }
}
