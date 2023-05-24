using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopSO", menuName = "ScriptableObjects/ShopSO")]
public class ShopSO : ScriptableObject
{
    public Sprite Image;
	public int Price;
	public bool IsPurchased;
	public TMPro.TextMeshProUGUI textMeshPro;
	public float DamageIncrease;
	public float HealthIncrease;
	public int PotIncrease;
	
}
