using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Utilities;

namespace ArcadeGalaxy.Managers 
{
    public class BulletManager : MonoBehaviour
    {
        // Static instance variable for singleton behaviour
        public static BulletManager Instance;

        [Header("Bullet Pool Config")]
        public GameObject bullet;
        public Transform bulletParentObject;
        public int bulletAmount;

        private ObjectPool bulletPool;
        public List<GameObject> bulletList;

        private void Awake()
        {
            if (BulletManager.Instance == null)
            {
                BulletManager.Instance = this;
            }
            else
                Destroy(this.gameObject);

            bulletPool = this.GetComponent<ObjectPool>();
            bulletPool.InitPool(bullet, bulletAmount);
        }

        private void Start()
        {
            CreateBullets();
        }

        private void CreateBullets()
        {
            bulletList.Clear();
            bulletList.AddRange(bulletPool.GetObjects(bulletAmount));

            InitBullets();
        }

        private void InitBullets()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].transform.SetParent(bulletParentObject);
            }
        }
    }
}
