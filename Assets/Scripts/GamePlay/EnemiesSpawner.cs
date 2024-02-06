using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner enemiesSpawnerInstance;
    public bool work;

    [SerializeField] GameObject[] enemiesArray;
    [SerializeField] float[] spawnerTime;

    [SerializeField] int enemyPoolIndex;
    public bool canCreate;
    private float timer;


    private void Awake()
    {
        enemiesSpawnerInstance = this;
    }

    private void Start()
    {
        GetSpawnerTime();
    }

    private void Update()
    {
        if (canCreate)
        {
            if (work)
            {
                timer -= Time.deltaTime;
        
                if (timer < 0)
                {
                    GenerateEnemy();
                    GetSpawnerTime();
                }
            }
        }
    }

    private void GetSpawnerTime()
    {
        int randomIndex = Random.Range(0, spawnerTime.Length);
        float randomValue = spawnerTime[randomIndex];
        timer = randomValue;
    }


    private void GenerateEnemy()
    {
        if (canCreate)
        {
            enemyPoolIndex++;
            if (enemyPoolIndex >= enemiesArray.Length)
                enemyPoolIndex = 0;

            enemiesArray[enemyPoolIndex].SetActive(true);
            enemiesArray[enemyPoolIndex].transform.position = transform.position;
           
        }
    }

    public void DestroyThisObj()
    {
        if (!work)
        {
            EnemyMovement[] allEnemies = FindObjectsOfType<EnemyMovement>();

            foreach (EnemyMovement enemy in allEnemies)
            {
                Vector3 viewportPosition = Camera.main.WorldToViewportPoint(enemy.transform.position);
                if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
                    viewportPosition.y < 0 || viewportPosition.y > 1 ||
                    viewportPosition.z < 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }
    }

    public void StopWorking()
    {
        work = false;
    }
}