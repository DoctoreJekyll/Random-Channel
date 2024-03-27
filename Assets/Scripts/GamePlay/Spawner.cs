using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject[] objectsS;

        private Vector3 pos1;
        private Vector3 pos2;

        private void Start()
        {
            var position = transform.position;
            pos1 = position + new Vector3(0f,2f,0f);
            pos2 = position + new Vector3(0f, -2f - 0f);
            
            InvokeRepeating(nameof(InstantiateObjects), 5f, 5f);
        }

        private void InstantiateObjects()
        {
            int index = Random.Range(0, objectsS.Length);
            Vector3 randomVector =
                new Vector3(transform.position.x, Random.Range(pos1.y, pos2.y), transform.position.z);
            Instantiate(objectsS[index],randomVector, quaternion.identity);
        }
    }
}
