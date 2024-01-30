using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsMainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] mainMenuAnimations;
    [SerializeField] int mainMenuAnimationIndex;
    [SerializeField] float initialTimeAnimation,timeBetweenAnimations;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ActivateNextAnimation", initialTimeAnimation, timeBetweenAnimations);        
    }

    void ActivateNextAnimation()
    {
        DesactiveAllAnimations();

        mainMenuAnimationIndex++;

        if(mainMenuAnimationIndex >= mainMenuAnimations.Length)
        {
            mainMenuAnimationIndex = 0;
        }

        mainMenuAnimations[mainMenuAnimationIndex].SetActive(true);
    }

    void DesactiveAllAnimations()
    {
        for(int i=0; i<mainMenuAnimations.Length; i++)
        {
            mainMenuAnimations[i].SetActive(false);
        }
    }

   
}
