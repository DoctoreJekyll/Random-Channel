using DG.Tweening;
using UnityEngine;

namespace GamePlay.Boss
{
    public class BossMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            transform.DOMoveY(5f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

    }
}
