using System;
using System.Collections;
using Unity.VisualScripting;
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
        [SerializeField] private CapsuleCollider2D col2d;

        [Header("Animacion")]
        [SerializeField] private Animator animator;

        private bool colisionDead = false;//Deteccion de muerte por ciertos enemigos con layer y colision
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.layer == 11 && dead == false)
            {
                GameOverManager.gameOverManagerInstance.InitializeGameOver(true);
                dead = true;
                colisionDead = true;
                Debug.Log("Creo que este es el problema?");
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

        private bool dead = false;
        [SerializeField]private Rigidbody2D rb2d;
        private void Dead()
        {
            if (life <= 0 && dead == false)
            {
                dead = true;
                life = 0;

                animator.SetBool("Dead", true);
                rb2d.bodyType = RigidbodyType2D.Dynamic;

                CallDeadMoment();
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

        public void CallDeadMoment()
        {
            if (isABoss)
            {
                Debug.Log("init you win");
                GameOverManager.gameOverManagerInstance.InitilizeYouWin();
            }
            else if (!colisionDead)
            {
                GameOverManager.gameOverManagerInstance.InitializeGameOver(true);
                Debug.Log("Dyng");
            }
        }
    }
}
