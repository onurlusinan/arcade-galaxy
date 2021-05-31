using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Characters;
using ArcadeGalaxy.Managers;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ReturnToPool();

        Character enemy = collision.GetComponent<Character>();
        if (enemy != null)
            enemy.DecreaseHealth(damage);
    }

    /// <summary>
    /// Returns to pool by disabling object and resetting position
    /// </summary>
    private void ReturnToPool()
    {
        //Reset position and disable object
        this.gameObject.SetActive(false);
        this.transform.position = BulletManager.Instance.bulletParentObject.transform.position;
        this.transform.rotation = BulletManager.Instance.bulletParentObject.transform.rotation;
    }
}
