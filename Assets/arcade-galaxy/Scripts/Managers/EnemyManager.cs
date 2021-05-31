using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Utilities;
using ArcadeGalaxy.Characters;

namespace ArcadeGalaxy.Managers
{
    public class EnemyManager : MonoBehaviour
    {
        // Static instance variable for singleton behaviour
        public static EnemyManager Instance;

        [Header("Enemy Pool Config")]
        public GameObject enemy;
        public Transform enemySpawnLocation;
        public int enemyAmount;
        public float enemySpawnTime;

        private ObjectPool enemyPool;
        public List<GameObject> enemyList;
        private WaitForSeconds enemyDelay;

        private void Awake()
        {
            if (EnemyManager.Instance == null)
            {
                EnemyManager.Instance = this;
            }
            else
                Destroy(this.gameObject);

            enemyPool = this.GetComponent<ObjectPool>();
            enemyPool.InitPool(enemy, enemyAmount);

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
                enemyList[i].transform.SetParent(enemySpawnLocation);

                int index = Random.Range(1,4);
                switch (index)
                {
                    case 1:
                        enemyList[i].transform.position += new Vector3(-22.5f, 40, 0);
                        enemyList[i].transform.position += new Vector3(Random.Range(-50, 0), Random.Range(0, 50), 0);
                        break;
                    case 2:
                        enemyList[i].transform.position += new Vector3(22.5f, 40, 0);
                        enemyList[i].transform.position += new Vector3(Random.Range(0, 50), Random.Range(0, 50), 0);
                        break;
                    case 3:
                        enemyList[i].transform.position += new Vector3(-22.5f, -40, 0);
                        enemyList[i].transform.position += new Vector3(Random.Range(-50, 0), Random.Range(-50, 0), 0);
                        break;
                    case 4:
                        enemyList[i].transform.position += new Vector3(22.5f, -40, 0);
                        enemyList[i].transform.position += new Vector3(Random.Range(0, 50), Random.Range(-50, 0), 0);
                        break;
                }

                enemyList[i].SetActive(true);
                
                yield return enemyDelay;
            }
        }
    }
}
