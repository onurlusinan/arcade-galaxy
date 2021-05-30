using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
}
