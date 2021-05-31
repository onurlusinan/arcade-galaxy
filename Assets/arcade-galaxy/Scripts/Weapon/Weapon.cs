using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Managers;

namespace ArcadeGalaxy.Weapon 
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public Transform bullets;
        public GameObject bullet;

        public float fireSpeed;

        /// <summary>
        /// Main shoot method, finds eligible bullet from list and shoots it
        /// </summary>
        private void Shoot()
        {
            GameObject bullet = new GameObject();

            for (int i = 0; i < BulletManager.Instance.bulletList.Count; i++)
            {
                if (BulletManager.Instance.bulletList[i].activeInHierarchy == false)
                {
                    bullet = BulletManager.Instance.bulletList[i];
                    break; 
                }
            }

            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * fireSpeed;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }
}
