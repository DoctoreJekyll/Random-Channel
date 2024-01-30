using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterManager : MonoBehaviour
{
    [SerializeField] GameObject[] vhsFilter;
    [SerializeField] GameObject[] glassesFilter;
    [SerializeField] GameObject[] gameBoyFilter;

    [SerializeField] bool vhsActive, glassesActive, gameBoyActive;
    [SerializeField] AudioClip vhsClip, glassesClip, gameBoyClip;


    public void ActivateVHSFilter()
    {
        vhsActive = !vhsActive;
        MusicManager.musicManagerInstance.PlayFxSound(vhsClip);

        for (int i = 0; i < vhsFilter.Length; i++)
        {
            vhsFilter[i].SetActive(vhsActive);
        }      
    }

    public void ActivateglassesFilter()
    {
        glassesActive = !glassesActive;
        MusicManager.musicManagerInstance.PlayFxSound(glassesClip);

        for (int i = 0; i < glassesFilter.Length; i++)
        {
            glassesFilter[i].SetActive(glassesActive);
        }
    }

    public void ActivategameBoyFilter()
    {
        gameBoyActive = !gameBoyActive;
        MusicManager.musicManagerInstance.PlayFxSound(gameBoyClip);

        for (int i = 0; i < gameBoyFilter.Length; i++)
        {
            gameBoyFilter[i].SetActive(gameBoyActive);
        }
    }
}
