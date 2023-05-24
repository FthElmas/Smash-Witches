using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SW.Core
{
    public interface IHealth
    {
        public void DamageIntake(float damage);
        public bool isDead();
        public bool isStopFighting();
    }

}
