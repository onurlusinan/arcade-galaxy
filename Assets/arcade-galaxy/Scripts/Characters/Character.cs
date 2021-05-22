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

        private float isEnemy;

        internal float GetHealth()
        {
            return health;
        }

        internal float GetShield()
        {
            return shield;
        }

        internal float GetDamage()
        {
            return damage;
        }
    }
}
