using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance;
    [SerializeField] private GameObject initBoss;

    public bool timeStart;
    public float counter;
    [SerializeField] Text timeText;

    public int popCorn;
    [SerializeField] Text popCornText;

    [SerializeField] bool generateYouWinOneTime;
    private bool timeisZero;


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
        //CheckYouWinTimer();
    }

    void CounterTimeMethod()
    {
        if (timeStart && !timeisZero)
        {
            counter -= Time.deltaTime;
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
        if (counter <= 0 && !timeisZero)
        {
            timeisZero = true;
            counter = 0;
            timeText.text = "00:00";
            Instantiate(initBoss, transform.position, quaternion.identity);
        }

    }

    void CheckYouWinTimer()
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
