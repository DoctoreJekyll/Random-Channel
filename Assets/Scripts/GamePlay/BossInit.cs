using System;
using UnityEngine;

namespace GamePlay
{
    public class BossInit : MonoBehaviour
    {
        private PopCornSpawner popCornSpawner;
        private PlatformSpawner platformSpawner;
        private EnemiesSpawner enemiesSpawner;
        
        private void Awake()
        {
            popCornSpawner = FindObjectOfType<PopCornSpawner>();
            platformSpawner = FindObjectOfType<PlatformSpawner>();
            enemiesSpawner = FindObjectOfType<EnemiesSpawner>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            SetComponentsUnabled();
            DestroyRest();
        }

        private void SetComponentsUnabled()
        {
            popCornSpawner.StopWorking();
            platformSpawner.StopWorking();
            enemiesSpawner.StopWorking();
            
        }

        private void DestroyRest()
        {
            enemiesSpawner.DestroyThisObj();
            platformSpawner.DestroyThisObj();
            popCornSpawner.DestroyThisObj();
        }
    }
}
