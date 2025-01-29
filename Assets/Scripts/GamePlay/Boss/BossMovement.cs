using System;
using DG.Tweening;
using UnityEngine;

namespace GamePlay.Boss
{
    public class BossMovement : MonoBehaviour
    {

        [SerializeField] private float distance;
        [SerializeField] private float time;


        public float testVar;

        private void Awake()
        {
            testVar = PlayerPrefs.GetFloat("TotalScore");
        }

        // Start is called before the first frame update
        void Start()
        {
            transform.DOMoveY(distance, time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

    }
}
