using System.Collections;
using System.Collections.Generic;
using GamePlay;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner platformSpawnerInstance;
    public bool work;

    [SerializeField] List<GameObject> platformArray;
    [SerializeField] GameObject lastPlatformCreated;

    [SerializeField] Vector3 smallSeparation, regularSeparation, bigSeparation, bigestSeparation;
    [SerializeField] float smallHeight, highHeight;

    public bool isGameOver;


    private void Awake()
    {
        platformSpawnerInstance = this;
    }

    public void AddToPlatformArray(GameObject g)
    {
        if (work)
        {
            if (!isGameOver)
            {
                platformArray.Add(g);
                ActivatePlatform();
            }
        }
    }

    private void ActivatePlatform()
    {
        int procesedIndex = Random.Range(0, platformArray.Count);
        int randomDistance = Random.Range(0, 4);
        int randomHeight = Random.Range(0, 2);

        platformArray[procesedIndex].SetActive(true);
        
        if(randomDistance == 0)
            platformArray[procesedIndex].transform.position = lastPlatformCreated.transform.position + smallSeparation;
       
        else if (randomDistance == 1)
            platformArray[procesedIndex].transform.position = lastPlatformCreated.transform.position + regularSeparation;

        else if (randomDistance == 2)
            platformArray[procesedIndex].transform.position = lastPlatformCreated.transform.position + bigSeparation;

        else if (randomDistance == 3)
            platformArray[procesedIndex].transform.position = lastPlatformCreated.transform.position + bigestSeparation;


        if(randomHeight == 0)
            platformArray[procesedIndex].transform.position =
                new Vector3(platformArray[procesedIndex].transform.position.x, smallHeight,-2);

        if (randomHeight == 1)
            platformArray[procesedIndex].transform.position =
                new Vector3(platformArray[procesedIndex].transform.position.x, highHeight, -2);

        lastPlatformCreated = platformArray[procesedIndex];
        platformArray.Remove(platformArray[procesedIndex]);
    }
    
    public void DestroyThisObj()
    {
        if (!work)
        {
            GameObject[] allPlatf = GameObject.FindGameObjectsWithTag("Platform");

            foreach (GameObject platform in allPlatf)
            {
                Vector3 viewportPosition = Camera.main.WorldToViewportPoint(platform.transform.position);
                if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
                    viewportPosition.y < 0 || viewportPosition.y > 1 ||
                    viewportPosition.z < 0)
                {
                    Destroy(platform.gameObject);
                }
            }
        }
    }

    public void StopWorking()
    {
        work = false;
    }
}