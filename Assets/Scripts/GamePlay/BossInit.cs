using System;
using System.Collections;
using GamePlay.Boss;
using Unity.Mathematics;
using UnityEngine;

namespace GamePlay
{
    public class BossInit : MonoBehaviour
    {
        private PopCornSpawner popCornSpawner;
        private PlatformSpawner platformSpawner;
        private EnemiesSpawner enemiesSpawner;

        [SerializeField] private GameObject boss;
        [SerializeField] private Transform bossPos;

        public bool bossIsntStart;
        
        private void Awake()
        {
            popCornSpawner = FindObjectOfType<PopCornSpawner>();
            platformSpawner = FindObjectOfType<PlatformSpawner>();
            enemiesSpawner = FindObjectOfType<EnemiesSpawner>();

            bossPos = GameObject.FindWithTag("BossStart").transform;
            bossIsntStart = true;
        }

        private Shoot playerShoot;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (bossIsntStart)
            {
                if (col.gameObject.CompareTag("Player"))
                {
                    playerShoot = col.GetComponent<Shoot>();
                    bossIsntStart = false;
                    SetComponentsUnabled();
                    DestroyRest();

                    StartCoroutine(InstantiateBossCorroutine());

                }
            }

        }

        private void SetComponentsUnabled()
        {
            popCornSpawner.ChangeWorking();
            //platformSpawner.ChangeWorking();
            enemiesSpawner.ChangeWorking();
            
        }

        private void DestroyRest()
        {
            enemiesSpawner.DestroyThisObj();
            popCornSpawner.DestroyThisObj();
        }

        IEnumerator InstantiateBossCorroutine()
        {
            yield return new WaitForSeconds(2f);
            //GameOverManager.gameOverManagerInstance.StopMovements();
            playerShoot.enabled = true;
            Instantiate(boss, bossPos.position + (Vector3.right), quaternion.identity);
        }
    }
}
