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
        // Return bullet to pool
        ReturnToPool(); 

        // Do damage to character(enemy) that is collided with
        Character enemy = collision.GetComponent<Character>();
        if (enemy != null)
        { 
            enemy.DecreaseHealth(damage);
            Debug.Log("Bullet hit enemy. Health: " + enemy.GetHealth() + " / Damage done: " + damage);
            
            if (enemy.GetHealth() <= 0)
            {
                enemy.gameObject.SetActive(false);
                enemy.transform.position = EnemyManager.Instance.enemySpawnLocation.transform.position;
            }
        }  
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
