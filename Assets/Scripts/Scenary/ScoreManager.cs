using System;
using GamePlay;
using UnityEngine;
using UnityEngine.UI;

namespace Scenary
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager ScoreManagerInstance;
    
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
        [SerializeField] private float totalTimeScore;

    [SerializeField] private bool isInfinity;


        private void Awake()
        {
            ScoreManagerInstance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
        
<<<<<<< Updated upstream
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
=======
        }

        // Update is called once per frame
        void Update()
>>>>>>> Stashed changes
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

        private void OnDisable()
        {
            if (isInfinity)
            {
                PlayerPrefs.SetFloat("TotalScore", totalTimeScore);
            }
        }
    }
}
