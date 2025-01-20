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
        [SerializeField] private Vector3 bossPos;

        public bool bossIsntStart;
        
        private void Awake()
        {
            popCornSpawner = FindObjectOfType<PopCornSpawner>();
            platformSpawner = FindObjectOfType<PlatformSpawner>();
            enemiesSpawner = FindObjectOfType<EnemiesSpawner>();

            bossPos = new Vector3(11, -2, 0);
            bossIsntStart = true;
        }

        private Shoot playerShoot;
        [SerializeField] private GameObject bossPanel;

        private void Start()
        {
            bossPanel = GameObject.FindWithTag("BossPanel");
        }

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
            platformSpawner.ChangeWorking();
            enemiesSpawner.ChangeWorking();
            
        }

        private void DestroyRest()
        {
            platformSpawner.DestroyThisObj();
            enemiesSpawner.DestroyThisObj();
            popCornSpawner.DestroyThisObj();
        }

        IEnumerator InstantiateBossCorroutine()
        {
            yield return new WaitForSeconds(3.5f);
            foreach (Transform child in bossPanel.transform)
            {
                child.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(5f);
            //GameOverManager.gameOverManagerInstance.StopMovements();
            playerShoot.enabled = true;
            Instantiate(boss, bossPos, quaternion.identity);
        }
    }
}
