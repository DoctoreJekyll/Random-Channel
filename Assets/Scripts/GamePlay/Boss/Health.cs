using System;
using UnityEngine;

namespace GamePlay.Boss
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int life;

        private void Update()
        {
            Dead();
        }

        private void OnTriggerEnter(Collider other)
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if (projectile != null)
            {
                LoseLife();
                Destroy(projectile.gameObject);
            }
        }

        private void Dead()
        {
            if (life <= 0)
            {
                life = 0;
                Destroy(this.gameObject);
            }
        }


        private void LoseLife()
        {
            life -= 1;
        }


    }
}
