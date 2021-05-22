using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Utils;
using ArcadeGalaxy.Characters;

namespace ArcadeGalaxy.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        [Header("Enemy Pool Config")]
        public GameObject enemy;
        public Transform enemySpawnLocation;
        public int initPoolAmount;
        public int enemyAmount;
        public float enemySpawnTime;

        private ObjectPool enemyPool;
        public List<GameObject> enemyList;
        private WaitForSeconds enemyDelay;

        private void Awake()
        {
            enemyPool = this.GetComponent<ObjectPool>();
            enemyPool.InitPool(enemy, initPoolAmount);

            enemyDelay = new WaitForSeconds(enemySpawnTime);
        }

        private void Start()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            enemyList.Clear();
            enemyList.AddRange(enemyPool.GetObjects(enemyAmount));

            StartCoroutine(InitEnemies());
        }

        private IEnumerator InitEnemies()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                // SetSprites(type, enemyPool[i]); // At some point for enemy types

                enemyList[i].transform.SetParent(enemySpawnLocation);
                enemyList[i].SetActive(true);
                
                yield return enemyDelay;
            }
        }
    }
}
