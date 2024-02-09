using System.Collections;
using System.Collections.Generic;
using GamePlay;
using Scenary;
using UnityEngine;

public class PlayerBeginGame : MonoBehaviour
{
    public static PlayerBeginGame playerBeginGameInstance;

    [SerializeField] Animator playerAnimator;
    public bool gamePlayStart;
    [SerializeField] Parallax[] parallaxs;

    [SerializeField] PlatformMovement[] initialFloorInScene;
    [SerializeField] PopCorn[] initialPopCornInScene;

    [SerializeField] ScenaryProps scenaryProps;

    [SerializeField] AudioClip clip; //Audio Inicial de Carrera

    public bool blockByYouWin;


    private void Awake()
    {
        playerBeginGameInstance = this;
    }

    private void Start()
    {
        initialFloorInScene = FindObjectsOfType<PlatformMovement>();
    }

    public void BeginGame()
    {
        if (!blockByYouWin)
        {
            if (!gamePlayStart)
            {
                playerAnimator.SetBool("isDance", false);
                gamePlayStart = true;
                MusicManager.musicManagerInstance.PlayFxSound(clip);
            }

            for (int i = 0; i < parallaxs.Length; i++)
            {
                parallaxs[i].ChangeParallaxState(false);
            }

            for (int i = 0; i < initialFloorInScene.Length; i++)
            {
                initialFloorInScene[i].canRun = true;
            }

            for (int i = 0; i < initialPopCornInScene.Length; i++)
            {
                initialPopCornInScene[i].canRun = true;
            }

            PopCornSpawner.popCornSpawnerInstance.canCreate = true;
            ScoreManager.scoreManagerInstance.timeStart = true;
            EnemiesSpawner.enemiesSpawnerInstance.canCreate = true;
            scenaryProps.canRun = true;
        }
    }
}
