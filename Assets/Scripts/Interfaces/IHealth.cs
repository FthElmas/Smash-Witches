using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SW.Interface
{
    public interface IHealth
    {
        public void DamageIntake(float damage);
        public bool isDead();
        public bool isStopFighting();
    }

}
