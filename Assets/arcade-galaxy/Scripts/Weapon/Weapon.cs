using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeGalaxy.Weapon 
{
    public class Weapon : MonoBehaviour
    {
        public Transform firePoint;
        public Transform bullets;
        public GameObject bullet;

        private void Shoot()
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation, bullets);
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
