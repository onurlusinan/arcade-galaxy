using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ArcadeGalaxy.Managers;

namespace ArcadeGalaxy.Characters
{
    public class Enemy : Character
    {
        public Animator enemyAnimator;

        public void PlayDeathAnim()
        {
            enemyAnimator.SetTrigger("Explosion");
        }

        public void ReturnToPool()
        {
            this.gameObject.SetActive(false);
            this.transform.position = EnemyManager.Instance.enemySpawnLocation.transform.position;
        }
    }
}

