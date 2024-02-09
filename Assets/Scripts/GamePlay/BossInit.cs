using System;
using System.Collections;
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

        private bool bossIsStart;
        
        private void Awake()
        {
            popCornSpawner = FindObjectOfType<PopCornSpawner>();
            platformSpawner = FindObjectOfType<PlatformSpawner>();
            enemiesSpawner = FindObjectOfType<EnemiesSpawner>();

            bossPos = GameObject.FindWithTag("BossStart").transform;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            bossIsStart = true;
            
            if (bossIsStart)
            {
                SetComponentsUnabled();
                DestroyRest();

                StartCoroutine(InstantiateBossCorroutine());
                bossIsStart = false;
            }

        }

        private void SetComponentsUnabled()
        {
            popCornSpawner.ChangeWorking();
            platformSpawner.ChangeWorking();
            enemiesSpawner.ChangeWorking();
            
        }

        private void DestroyRest()
        {
            enemiesSpawner.DestroyThisObj();
            platformSpawner.DestroyThisObj();
            popCornSpawner.DestroyThisObj();
        }

        IEnumerator InstantiateBossCorroutine()
        {
            yield return new WaitForSeconds(2.5f);
            FloorSpawner.floorSpawnerInstance.CreateBigFloorByGameOver();
            yield return new WaitForSeconds(3f);
            GameOverManager.gameOverManagerInstance.StopMovements();
            Instantiate(boss, bossPos.position, quaternion.identity);
        }
    }
}
