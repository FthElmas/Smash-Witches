using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHolderSingleton : MonoBehaviour
{
    private static ShopHolderSingleton _instance;
    public static ShopHolderSingleton Instance{get{return _instance;}}
    [SerializeField]private ShopSO _shopData;
    public ShopSO ShopData{get{return _shopData;}}
    

    

    private void Awake()
    {
        if (_instance == null) 
            {
                _instance = this;
                DontDestroyOnLoad (gameObject);
            } 
            else 
            {
                Destroy (gameObject);
            }
    }

    
}
