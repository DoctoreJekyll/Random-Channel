using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController playerInputControllerInstance;

    public Rigidbody2D rb2D;
    [SerializeField] Vector2 jumpForce, doubleJumpForce;
    public bool isDoubleJump;

    [SerializeField] AudioClip jumpClip;
    
    [SerializeField] PlayerBeginGame playerBeginGame;

    //----------Para el youwin
    public bool runByYouWin;
    [SerializeField] Vector2 playerVelocity;


    private void Awake()
    {
        playerInputControllerInstance = this;
    }

    public void JumpForce()
    {
        if (playerBeginGame.gamePlayStart && FloorChecker.floorCheckerInstance.isInFloor && !isDoubleJump && !runByYouWin)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(jumpForce);
            MusicManager.musicManagerInstance.PlayFxSound(jumpClip);
        }

        else if (playerBeginGame.gamePlayStart && !FloorChecker.floorCheckerInstance.isInFloor && !isDoubleJump && !runByYouWin)
        {
            rb2D.velocity = Vector2.zero;
            isDoubleJump = true;
            rb2D.AddForce(doubleJumpForce);
            FloorChecker.floorCheckerInstance.animator.SetBool("isDoubleJump", true);
            MusicManager.musicManagerInstance.PlayFxSound(jumpClip);
        }
    }

    private void FixedUpdate()
    {
        if (runByYouWin)
        {
            rb2D.constraints = RigidbodyConstraints2D.None;
            rb2D.freezeRotation = true;
            if (rb2D.velocity.y<=0)
                rb2D.velocity = new Vector2(playerVelocity.x, rb2D.velocity.y*50) * Time.deltaTime;
        }
    }
}
