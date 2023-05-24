using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatSO", menuName = "ScriptableObjects/EnemyStatSO")]
public class EnemyStatSO : ScriptableObject
{
    public float WeaponDamage;
    public int EnemyNumber;
    public float Speed;
    public float MaxHealth;


}
