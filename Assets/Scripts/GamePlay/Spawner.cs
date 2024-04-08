using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay
{
    public class Spawner : MonoBehaviour
    {
        public static Spawner Instance;
        

        [SerializeField] private GameObject[] objectsS;
        [SerializeField] private bool randomInstantiate;
         private float timer;

        public bool canCreate;
        public bool work;

        private Vector3 pos1;
        private Vector3 pos2;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            var position = transform.position;
            pos1 = position + new Vector3(0f,2f,0f);
            pos2 = position + new Vector3(0f, -2f - 0f);
            timer = Random.Range(7f, 10f);
        }

        private void CreateObj()
        {
            if (randomInstantiate)
            {
                InstantiateRandomPos();
            }
            else
            {
                InstantiateNormal();
            }
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
                        CreateObj();
                        timer = Random.Range(4f, 6f);
                    }
                }
            }

        }

        private void InstantiateRandomPos()
        {
            int index = Random.Range(0, objectsS.Length);
            Vector3 randomVector =
                new Vector3(transform.position.x, Random.Range(pos1.y, pos2.y), transform.position.z);
            Instantiate(objectsS[index],randomVector, quaternion.identity);
        }

        private void InstantiateNormal()
        {
            int index = Random.Range(0, objectsS.Length);
            Instantiate(objectsS[index], transform.position, Quaternion.identity);
        }
    }
}
