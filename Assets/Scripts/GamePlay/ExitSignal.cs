using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSignal : MonoBehaviour
{
    [SerializeField] int nextPhase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //Bajar volumen
            GameOverManager.gameOverManagerInstance.CoroutineYouWinPhase();
            StartCoroutine(CoroutineNextLevel());
        }
    }

    IEnumerator CoroutineNextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(nextPhase);
    }
}
