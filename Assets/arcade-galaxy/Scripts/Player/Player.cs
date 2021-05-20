using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float health;
    private float shield;
    private float damage;

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
