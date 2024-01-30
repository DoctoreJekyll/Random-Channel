using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BocadilloPool : MonoBehaviour
{
    public static BocadilloPool bocadilloPoolInstance;
    [SerializeField] GameObject[] bocadilloArray;
    [SerializeField] int bocadilloIndex;


    private void Awake()
    {
        bocadilloPoolInstance = this;
    }

    public void GenerateBocadillo(Transform t)
    {
        bocadilloIndex++;
        if (bocadilloIndex >= bocadilloArray.Length)
            bocadilloIndex = 0;

        bocadilloArray[bocadilloIndex].SetActive(true);
        bocadilloArray[bocadilloIndex].transform.position = t.position + new Vector3(0,0,-0.5f);         
    }
}