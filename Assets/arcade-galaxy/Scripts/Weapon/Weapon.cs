using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeGalaxy.Weapon 
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public GameObject bullet;

        private void Shoot()
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
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
