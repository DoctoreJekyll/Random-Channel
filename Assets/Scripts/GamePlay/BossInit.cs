using UnityEngine;

namespace GamePlay
{
    public class BossInit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            GameOverManager.gameOverManagerInstance.CoroutineYouWinPhase();
        }
    }
}
