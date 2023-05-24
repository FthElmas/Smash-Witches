using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SW.Core;


namespace SW.Shop
{
    public class Shop : MonoBehaviour
    {
        #region Singleton:Shop

	public static Shop Instance;

	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy (gameObject);
	}

	#endregion

	

	public List<ShopSO> ShopItemsList;
	[SerializeField] Animator NoCoinsAnim;
 
	GameObject ui;
	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] private Transform ShopScrollView;
	[SerializeField] private GameObject ShopPanel;
	Button buyBtn;
	StatHolderSingleton statHolder;
	private float damageIncrease;

	void Start ()
	{
		damageIncrease = ShopHolderSingleton.Instance.ShopData.DamageIncrease;
		statHolder = StatHolderSingleton.FindAnyObjectByType<StatHolderSingleton>();
		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++) {
			g = Instantiate (ItemTemplate, ShopScrollView);
			g.transform.GetChild (0).GetComponent <Image> ().sprite = ShopItemsList [i].Image;
			g.transform.GetChild (1).GetChild (0).GetComponent <TMPro.TextMeshProUGUI> ().text = ShopItemsList [i].Price.ToString ();
			buyBtn = g.transform.GetChild (2).GetComponent <Button>();
			
			
			
			if (ShopItemsList [i].IsPurchased) {
				DisableBuyButton ();
			}
			
			buyBtn.AddEventListener(i, OnShopItemBtnClicked);
			
		}
	}
	
	void OnShopItemBtnClicked (int itemIndex)
	{
		if (Coin.Instance.HasEnoughCoins (ShopItemsList [itemIndex].Price)) {
			Coin.Instance.DecreaseCoin (ShopItemsList [itemIndex].Price);
			//purchase Item
			ShopItemsList [itemIndex].IsPurchased = true;
			StatHolderSingleton.Instance.IncreaseDamage(ShopItemsList[itemIndex].DamageIncrease);
			StatHolderSingleton.Instance.IncreaseHealth(ShopItemsList[itemIndex].HealthIncrease);
			StatHolderSingleton.Instance.IncreasePot(ShopItemsList[itemIndex].PotIncrease);

			//disable the button
			buyBtn = ShopScrollView.GetChild (itemIndex).GetChild (2).GetComponent <Button> ();
			DisableBuyButton ();
			//change UI text: coins
			Coin.Instance.UpdateAllCoinsUIText ();

			
		} else {
			NoCoinsAnim.SetTrigger ("NoCoins");
			Debug.Log ("You don't have enough coins!!");
		}
	}

	void DisableBuyButton ()
	{
		buyBtn.interactable = false;
		buyBtn.transform.GetChild (0).GetComponent <TMPro.TextMeshProUGUI> ().text = "PURCHASED";
	}
	/*---------------------Open & Close shop--------------------------*/
	public void OpenShop ()
	{
		ShopPanel.SetActive (true);
	}

	public void CloseShop ()
	{
		ShopPanel.SetActive (false);
	}
    }
}
