using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunContinous : MonoBehaviour
{
    //NO USADO DE MOMENTO
    public static PlayerRunContinous playerRunContinousInstance;

    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Vector2 playerVelocity;

    public bool canRun;

    [SerializeField] float smoothTime = .05f;
    float velocitySmoothing;


    // Start is called before the first frame update
    void Awake()
    {
        playerRunContinousInstance = this;
    }

    private void FixedUpdate()
    {
        if (canRun)
        {           
            rb2D.velocity = new Vector2(1,0)* Time.deltaTime * Mathf.SmoothDamp(rb2D.velocity.x, playerVelocity.x, ref velocitySmoothing, smoothTime);

            //rb2D.velocity = playerVelocity;
        }
    }
}
