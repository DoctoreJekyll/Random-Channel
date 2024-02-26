using System;
using Unity.Mathematics;
using UnityEngine;

namespace GamePlay.Boss
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform shootPos;
        [SerializeField] private float timeToShoot;
        [SerializeField] private bool autoShoot;
        private float rate;

        private void Start()
        {
            rate = timeToShoot;
        }

        private void Update()
        {
            if (autoShoot)
            {
                rate -= Time.deltaTime;
                if (rate < 0)
                {
                    CreateProjectile();
                    rate = timeToShoot;
                }
            }
        }

        private void CreateProjectile()
        {
            Instantiate(projectile, shootPos.position, quaternion.identity);
        }
        
    }
}
