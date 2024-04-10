using System;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay
{
    public class OnTriggerEvent : MonoBehaviour
    {
        
        [SerializeField] private UnityEvent eventTrigg;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                eventTrigg.Invoke();
                this.gameObject.SetActive(false);
            }
        }

        public void KillPlayer()
        {
            GameOverManager.gameOverManagerInstance.InitializeGameOver(true);
        }
    }
}
