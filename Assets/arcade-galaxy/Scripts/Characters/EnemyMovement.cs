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

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy collides with Enemy!");
            }
            else if (collider.gameObject.tag == "Player")
            {
                Debug.Log("Enemy collides with Player!");
            }
        }

        private void Update()
        {
            // Keep the rotation 
            transform.rotation = Quaternion.identity;

            if (Vector2.Distance(transform.position, target.position) > distanceLimit)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
            }
        }
    }
}
