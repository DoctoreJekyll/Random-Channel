using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartPhase : MonoBehaviour
{

    [SerializeField] private MonoBehaviour mGameObject;
    [SerializeField] private Animator mAnimator;

    private Vector3 initPosition;
    private void OnEnable()
    {
        mGameObject.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        StartCoroutine(StartMove());
    }

    IEnumerator StartMove()
    {
        MoveToStartPosition();
        yield return new WaitForSeconds(1f);
        mGameObject.enabled = true;
    }

    private void MoveToStartPosition()
    {

        Vector3 extraPos = new Vector3(-4.5f, 0, 0);
        Vector3 newPos = initPosition + extraPos;

        transform.DOMoveX(newPos.x, 1f);
    }
}
