using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestChangeScene : MonoBehaviour
{
   
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip retroButtonClip;
    [SerializeField] float delayTime;

    [SerializeField] int sceneIndex;

    public void TapPlayButtonMethod()
    {        
        source.PlayOneShot(retroButtonClip);
        StartCoroutine(ChangeSceneCoroutine());
    }

    IEnumerator ChangeSceneCoroutine()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
