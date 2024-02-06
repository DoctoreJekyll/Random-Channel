using System.Collections;
using System.Collections.Generic;
using GamePlay;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public static FloorSpawner floorSpawnerInstance;

    [SerializeField] List<GameObject> floorArray;
    [SerializeField] GameObject lastFloorCreated, preLastFloorCreated, prepreLastFloorCreated;

    [SerializeField] Vector3 regularSeparation, holeSeparation, doubleHoleSeparation;

    public bool isGameOver;

    //-------------Parte de acabar fase
    [SerializeField] GameObject bigFloorFinalPhase;


    private void Awake()
    {
        floorSpawnerInstance = this;
    }

    public void AddToFloorArray(GameObject g)
    {
        if (!isGameOver)
        {
            floorArray.Add(g);
            ActivateFloor();
        }
    }

    public void ActivateFloor()
    {
        int procesedIndex = Random.Range(0, floorArray.Count);

        floorArray[procesedIndex].SetActive(true);

        if (floorArray[procesedIndex].GetComponent<PlatformMovement>().isHole)
        {
            if (lastFloorCreated.GetComponent<PlatformMovement>().isHole)
            {
                floorArray[procesedIndex].transform.position = lastFloorCreated.transform.position + doubleHoleSeparation;
            }
            else
            {
                floorArray[procesedIndex].transform.position = lastFloorCreated.transform.position + holeSeparation;
            }            
        }
        else
        {
            if (lastFloorCreated.GetComponent<PlatformMovement>().isHole)
            {
                floorArray[procesedIndex].transform.position = lastFloorCreated.transform.position + holeSeparation;
            }
            else
            {
                floorArray[procesedIndex].transform.position = lastFloorCreated.transform.position + regularSeparation;
            }           
        }

        prepreLastFloorCreated = preLastFloorCreated;
        preLastFloorCreated = lastFloorCreated;
        lastFloorCreated = floorArray[procesedIndex];       
        floorArray.Remove(floorArray[procesedIndex]);                  
    }

    public void CreateBigFloorByGameOver()
    {
        TestPrepareFloorForBig();
        if (/*lastFloorCreated*/prepreLastFloorCreated.GetComponent<PlatformMovement>().isHole)
        {
           GameObject bigFloorTemp = Instantiate(bigFloorFinalPhase,
           /*lastFloorCreated*/prepreLastFloorCreated.transform.position + holeSeparation, Quaternion.identity);
        }
        else
        {
            GameObject bigFloorTemp = Instantiate(bigFloorFinalPhase,
           /*lastFloorCreated*/prepreLastFloorCreated.transform.position + regularSeparation, Quaternion.identity);
        }       
    }
    
    void TestPrepareFloorForBig()
    {
        lastFloorCreated.SetActive(false);
        preLastFloorCreated.SetActive(false);
    }
}
