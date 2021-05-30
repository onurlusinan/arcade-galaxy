using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Characters;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character enemy = collision.GetComponent<Character>();
        if (enemy != null)
            enemy.DecreaseHealth(damage);
        
        Destroy(this.gameObject);
    }
}
