using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Boss
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [SerializeField] private int life;
        [SerializeField] private bool isABoss;
        [SerializeField] private bool invulnerable;

        private Rigidbody2D rb2d;
        [SerializeField] private CapsuleCollider2D collider2D;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == 11)
            {
                Debug.Log(col.name);
                GameOverManager.gameOverManagerInstance.InitializeGameOver(true);
            }
            else
            {
                Projectile projectile = col.GetComponent<Projectile>();
                if (projectile != null)
                {
                    LoseLife();
                    StartCoroutine(HitCorroutine());
                    Destroy(projectile.gameObject);
                }
            }
        }

        private void Update()
        {
            Dead();
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
            if (!invulnerable)
            {
                life -= 1;
            }
        }

        private IEnumerator HitCorroutine()
        {
            invulnerable = true;
            for (int i = 0; i < 7; i++)
            {
                Hit(Color.red);
                yield return new WaitForSeconds(0.05f);
                Hit(Color.white);
                yield return new WaitForSeconds(0.05f);
            }
            Hit(Color.white);
            invulnerable = false;
        }

        private void Hit(Color color)
        {
            spriteRenderer.color = color;
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
