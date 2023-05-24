using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SW.Core
{
    public interface IStatIncrease
    {
        void IncreaseHealth(float health);

        void IncreaseDamage(float damage);
    }
}
