using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StatsSO", menuName = "ScriptableObjects/StatsSO")]
public class StatsSO : ScriptableObject
{
   public float Damage;
   public float MaxHealth;
   public float Speed;
   public float SpeedBuffTime;
   public float Skill2SpeedBuff;
   public int HealthPotNumber;
   public float Skill1Cooldown;
   public float Skill2Cooldown;
   public float BasicAttackCooldown;
   

    
}
