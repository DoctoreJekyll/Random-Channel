using System;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Boss
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int life;

        [SerializeField] private bool isABoss;
        
        

        private void Update()
        {
            Dead();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Projectile projectile = col.GetComponent<Projectile>();
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
                this.gameObject.SetActive(false);
            }
        }


        private void LoseLife()
        {
            life -= 1;
        }

        private void OnDisable()
        {
            if (isABoss)
            {
                GameOverManager.gameOverManagerInstance.InitilizeYouWin();
            }
            else
            {
                GameOverManager.gameOverManagerInstance.InitializeGameOver(true);
            }
        }
    }
}
