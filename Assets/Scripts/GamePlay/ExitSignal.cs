using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSignal : MonoBehaviour
{
    [SerializeField] int nextPhase;
    [SerializeField] private bool autoLoad;

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
        yield return new WaitForSeconds(2.5f);
        if (!autoLoad)
        {
            LoadSceneWithParam();
        }
        else
        {
            LoadSceneWithoutParam();
        }
    }

    private void LoadSceneWithParam()
    {
        SceneManager.LoadScene(nextPhase);
    }

    private void LoadSceneWithoutParam()
    {
        int newScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(newScene + 1);
    }
}
