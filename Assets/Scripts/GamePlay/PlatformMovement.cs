using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public int idFloorIndex;

    [SerializeField] Rigidbody2D rb2D;
    public Vector2 platformMovement;

    public bool canRun, isHole;

    [SerializeField] float smoothTime = .05f;


    private void FixedUpdate()
    {
        if (canRun)
        {
            //rb2D.velocity = new Vector2(1, 0) * Time.deltaTime * Mathf.SmoothDamp(rb2D.velocity.x, platformMovement.x, ref velocitySmoothing, smoothTime);
            rb2D.velocity = platformMovement * Time.deltaTime;
        }
    }
}
