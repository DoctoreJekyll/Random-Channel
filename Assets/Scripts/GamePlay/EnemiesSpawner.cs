using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public static EnemiesSpawner enemiesSpawnerInstance;

    [SerializeField] GameObject[] enemiesArray;
    [SerializeField] float[] spawnerTime;

    [SerializeField] int enemyPoolIndex;
    public bool canCreate;


    private void Awake()
    {
        enemiesSpawnerInstance = this;
    }

    private void Start()
    {
        Invoke("GenerateEnemy", spawnerTime[Random.Range(0, spawnerTime.Length)]);
    }

    public void GenerateEnemy()
    {
        if (canCreate)
        {
            enemyPoolIndex++;
            if (enemyPoolIndex >= enemiesArray.Length)
                enemyPoolIndex = 0;

            enemiesArray[enemyPoolIndex].SetActive(true);
            enemiesArray[enemyPoolIndex].transform.position = transform.position;
           
        }
        Invoke("GenerateEnemy", spawnerTime[Random.Range(0, spawnerTime.Length)]);
    }
}