using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornSpawner : MonoBehaviour
{
    public static PopCornSpawner popCornSpawnerInstance;

    [SerializeField] GameObject[] popCornArray;
    [SerializeField] GameObject popCornForRow1, popCornForRow2, popCornForRow3, popCornForRow4;
    [SerializeField] float smallHeight, mediumHeight, highHeight;
    [SerializeField] float[] spawnerTime;

    [SerializeField] int popCornPoolIndex;
    public bool canCreate;


    private void Awake()
    {
        popCornSpawnerInstance = this;
    }

    private void Start()
    {
        Invoke("GeneratePopCorn", spawnerTime[Random.Range(0, spawnerTime.Length)]);
    }

    public void GeneratePopCorn()
    {
        if (canCreate)
        {
            int tempPopCornRow = Random.Range(0, 9);
            if (tempPopCornRow != 8)
            {
                popCornPoolIndex++;
                if (popCornPoolIndex >= popCornArray.Length)
                    popCornPoolIndex = 0;

                popCornArray[popCornPoolIndex].SetActive(true);
                popCornArray[popCornPoolIndex].transform.position = new Vector3(transform.position.x, RandomizePopCornHeight(), transform.position.z);
            }
            else
            {
                StartCoroutine(CoroutineCreatePopCornRow());
            }
        }
        Invoke("GeneratePopCorn", spawnerTime[Random.Range(0, spawnerTime.Length)]);
    }

    float RandomizePopCornHeight()
    {
        int temp = Random.Range(0, 3);
        if (temp == 0) return smallHeight;
        else if (temp == 1) return mediumHeight;
        else return highHeight;
    }

    IEnumerator CoroutineCreatePopCornRow()
    {
        float temp = RandomizePopCornHeight();
        Instantiate(popCornForRow1, new Vector3(transform.position.x, temp, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(popCornForRow2, new Vector3(transform.position.x, temp, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(popCornForRow3, new Vector3(transform.position.x, temp, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(popCornForRow4, new Vector3(transform.position.x, temp, transform.position.z), Quaternion.identity);
    }
}
