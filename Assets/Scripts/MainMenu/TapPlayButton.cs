using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapPlayButton : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float delayTime;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip retroButtonClip;

    [SerializeField] int sceneIndex;
    [SerializeField] private string sceneName;

    public void TapPlayButtonMethod()
    {
        animator.SetBool("TapButton", true);
        source.PlayOneShot(retroButtonClip);
        StartCoroutine(ChangeSceneCoroutine());
    }

    IEnumerator ChangeSceneCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
