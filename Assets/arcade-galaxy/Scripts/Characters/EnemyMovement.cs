using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeGalaxy.Characters
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("Enemy Follow Config")]
        public float followSpeed;
        public float distanceLimit;

        private Transform target;
        private BoxCollider2D coll;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            coll = this.GetComponent<BoxCollider2D>();
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy collides with Enemy!");
            }
            else if (coll.gameObject.tag == "Player")
            {
                Debug.Log("Enemy collides with Player!");
            }
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, target.position) > distanceLimit)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
        }
    }
}
