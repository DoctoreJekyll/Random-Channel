using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using GamePlay;
using GamePlay.Boss;
using Scenary;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager gameOverManagerInstance;

    private bool isWinning;

    [SerializeField] private float timeToStartWinCorroutine;
    [SerializeField] Parallax[] parallaxs;
    [SerializeField] PlatformMovement[] platforms;
    [SerializeField] PopCorn[] popCorns;
    [SerializeField] EnemyMovement[] enemyMovements;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] AudioClip[] gameOverClips;
    [SerializeField] AudioClip clipCaida;

    [SerializeField] private MonoBehaviour playerShootComponent;
    

    private void Awake()
    {
        gameOverManagerInstance = this;
        isWinning = false;
    }

    private bool repairSoundBoolean;
    public void InitializeGameOver(bool isEnemy) 
    {
        if (!isWinning)
        {
            if (isEnemy && !repairSoundBoolean)
            {
                int temp = Random.Range(0, gameOverClips.Length);
                MusicManager.musicManagerInstance.PlayFxSound(gameOverClips[temp]);
                repairSoundBoolean = true;
                Debug.Log("Dyng sonidos muchos");
            }
            else
            {
                //MusicManager.musicManagerInstance.PlayFxSound(clipCaida);
            }

            for(int i=0; i < parallaxs.Length; i++)
            {
                parallaxs[i].ChangeParallaxState(true);
            }

            platforms = FindObjectsOfType<PlatformMovement>();
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].platformMovement = Vector2.zero;
            }

            PlatformSpawner.platformSpawnerInstance.isGameOver = true;
            FloorSpawner.floorSpawnerInstance.isGameOver = true;

            popCorns = FindObjectsOfType<PopCorn>();
            for (int i = 0; i < popCorns.Length; i++)
            {
                popCorns[i].popCornMovement = Vector2.zero;
            }

            enemyMovements = FindObjectsOfType<EnemyMovement>();
            for (int i = 0; i < enemyMovements.Length; i++)
            {
                enemyMovements[i].enemyMovement = Vector2.zero;
            }

            PopCornSpawner.popCornSpawnerInstance.canCreate = false;
            ScoreManager.ScoreManagerInstance.timeStart = false;
            EnemiesSpawner.enemiesSpawnerInstance.canCreate = false;
            gameOverPanel.SetActive(true);
        }

    }
    

    public void InitilizeYouWin()
    {
        StartCoroutine(WinCorroutine());
        isWinning = true;
        //StartCoroutine(CoroutineYouWinPhase());
    }

    IEnumerator WinCorroutine()
    {
        yield return new WaitForSeconds(timeToStartWinCorroutine);
        FloorSpawner.floorSpawnerInstance.CreateBigFloorByGameOver();
        PlayerBeginGame.playerBeginGameInstance.blockByYouWin = true;     

        PlatformSpawner.platformSpawnerInstance.isGameOver = true;
        FloorSpawner.floorSpawnerInstance.isGameOver = true;

        PopCornSpawner.popCornSpawnerInstance.canCreate = false;
        ScoreManager.ScoreManagerInstance.timeStart = false;
        EnemiesSpawner.enemiesSpawnerInstance.canCreate = false;
        
        playerShootComponent = GameObject.FindWithTag("Player").GetComponent<Shoot>();
        playerShootComponent.enabled = false;
    }

    public void CoroutineYouWinPhase()
    {
        //yield return new WaitForSeconds(9f);
        PlayerInputController.playerInputControllerInstance.runByYouWin = true;

        StopMovements();

        if (!ScoreManager.ScoreManagerInstance.needBoss)
        {
            popCorns = FindObjectsOfType<PopCorn>();
            for (int i = 0; i < popCorns.Length; i++)
            {
                popCorns[i].popCornMovement = Vector2.zero;
            }

            enemyMovements = FindObjectsOfType<EnemyMovement>();
            for (int i = 0; i < enemyMovements.Length; i++)
            {
                enemyMovements[i].enemyMovement = Vector2.zero;
                enemyMovements[i].gameObject.GetComponent<Collider2D>().enabled = false; //Nuevo
                enemyMovements[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f; //Nuevo
                //enemyMovements[i].transform.GetChild(0).GetComponent<Collider2D>().enabled = false; //Nuevo
            } 
        }
      
    }

    private void StopMovements()
    {
        foreach (var t in parallaxs)
        {
            t.ChangeParallaxState(true);
        }

        platforms = FindObjectsOfType<PlatformMovement>();
        foreach (var t in platforms)
        {
            t.platformMovement = Vector2.zero;
        }
    }
}
