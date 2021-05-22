using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Follow Config")]
    public float followSpeed;
    public float distanceLimit;
    
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > distanceLimit)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
    }
}
