using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeGalaxy.Characters
{
    public class Character : MonoBehaviour
    {
        private float health;
        private float shield;
        private float damage;

        internal virtual float GetHealth()
        {
            return health;
        }

        internal virtual float GetShield()
        {
            return shield;
        }

        internal virtual float GetDamage()
        {
            return damage;
        }

        internal virtual void DecreaseHealth(float amount)
        {
            this.health -= amount; 
        }

        internal virtual void DecreaseShield(float amount)
        {
            this.shield -= amount;
        }
    }
}
