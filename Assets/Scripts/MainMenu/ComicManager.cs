using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{
    [SerializeField] GameObject[] comicPages;
    [SerializeField] int pageIndex;
    [SerializeField] int sceneIndex;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    public void ChangePage()
    {
        pageIndex++;
        if (pageIndex < 3)
        {            
            comicPages[pageIndex].SetActive(true);
            source.PlayOneShot(clip);
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }

    }
}
