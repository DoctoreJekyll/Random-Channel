using System.Collections;
using System.Collections.Generic;
using GamePlay;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance;
    
    public bool timeStart;
    public float counter;
    [SerializeField] Text timeText;

    public int popCorn;
    [SerializeField] Text popCornText;

    [SerializeField] bool generateYouWinOneTime;
    private bool timeisZero;
    
    [Header("BossConfig")]
    [SerializeField] private BossStart bossStart;
    public bool needBoss;

    [SerializeField] private bool isInfinity;


    private void Awake()
    {
        scoreManagerInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CounterTimeMethod();
        TimeIsZero();

        if (!needBoss)
        {
            CheckYouWinTimer();
        }
        
    }

    void CounterTimeMethod()
    {
        if (timeStart && !timeisZero && !isInfinity)
        {
            counter -= Time.deltaTime;
            string min = Mathf.Floor(counter / 60).ToString("00");
            string seg = Mathf.Floor(counter % 60).ToString("00");
            timeText.text = min + ":" + seg;
        }
        else if (isInfinity && timeStart)
        {
            counter += Time.deltaTime;
            string min = Mathf.Floor(counter / 60).ToString("00");
            string seg = Mathf.Floor(counter % 60).ToString("00");
            timeText.text = min + ":" + seg;
        }
    }

    public void AddPopCorn(int n)
    {
        popCorn += n;
        popCornText.text = popCorn.ToString();
    }

    private void TimeIsZero()
    {
        if (counter <= 0 && !timeisZero && !isInfinity)
        {
            timeisZero = true;
            counter = 0;
            timeText.text = "00:00";
            if (needBoss)
            {
                bossStart.BossPhaseInit();
            }
            
        }

    }

    public void CheckYouWinTimer()
    {
        if(counter <= 0 && !generateYouWinOneTime) //Menos 5 pruebas jose diciembre
        {
            generateYouWinOneTime = true;
            counter = 0;
            timeText.text = "00:00";

            GameOverManager.gameOverManagerInstance.InitilizeYouWin();
        }
    }
}
