using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SW.Shop
{
    public class Coin : MonoBehaviour
    {
        public int coin{get; set;}

        
        public void AddCoinDrop(int coin)
        {
            this.coin += coin;

        }

        public void DecreaseCoin(int price)
        {
            this.coin -= price;
        }

        


    }

}
