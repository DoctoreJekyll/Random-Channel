using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager gameOverManagerInstance;

    [SerializeField] Parallax[] parallaxs;
    [SerializeField] PlatformMovement[] platforms;
    [SerializeField] PopCorn[] popCorns;
    [SerializeField] EnemyMovement[] enemyMovements;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] AudioClip[] gameOverClips;
    [SerializeField] AudioClip clipCaida;
    

    private void Awake()
    {
        gameOverManagerInstance = this;
    }

    public void InitializeGameOver(bool isEnemy) 
    {
        if (isEnemy)
        {
            int temp = Random.Range(0, gameOverClips.Length);
            MusicManager.musicManagerInstance.PlayFxSound(gameOverClips[temp]);
        }
        else
        {
            MusicManager.musicManagerInstance.PlayFxSound(clipCaida);
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
        ScoreManager.scoreManagerInstance.timeStart = false;
        EnemiesSpawner.enemiesSpawnerInstance.canCreate = false;
        gameOverPanel.SetActive(true);
    }

    public void InitilizeYouWin()
    {        
        FloorSpawner.floorSpawnerInstance.CreateBigFloorByGameOver();
        PlayerBeginGame.playerBeginGameInstance.blockByYouWin = true;     

        PlatformSpawner.platformSpawnerInstance.isGameOver = true;
        FloorSpawner.floorSpawnerInstance.isGameOver = true;

        PopCornSpawner.popCornSpawnerInstance.canCreate = false;
        ScoreManager.scoreManagerInstance.timeStart = false;
        EnemiesSpawner.enemiesSpawnerInstance.canCreate = false;

        //StartCoroutine(CoroutineYouWinPhase());
    }

    public void CoroutineYouWinPhase()
    {
        //yield return new WaitForSeconds(9f);

        PlayerInputController.playerInputControllerInstance.runByYouWin = true;

        for (int i = 0; i < parallaxs.Length; i++)
        {
            parallaxs[i].ChangeParallaxState(true);
        }

        platforms = FindObjectsOfType<PlatformMovement>();
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].platformMovement = Vector2.zero;
        }

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
            enemyMovements[i].transform.GetChild(0).GetComponent<Collider2D>().enabled = false; //Nuevo
        }       
    }
}
