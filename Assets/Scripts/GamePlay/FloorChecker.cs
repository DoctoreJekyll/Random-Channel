using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour
{
    public static FloorChecker floorCheckerInstance;

    public Animator animator;

    public bool isInFloor;


    private void Awake()
    {
        floorCheckerInstance = this;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
        {
            isInFloor = true;
            animator.SetBool("isJump", false);
            animator.SetBool("isDoubleJump", false);
            PlayerInputController.playerInputControllerInstance.isDoubleJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
        {
            isInFloor = false;
            animator.SetBool("isJump", true);
        }
    }
}
