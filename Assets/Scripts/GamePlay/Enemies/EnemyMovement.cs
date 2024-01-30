using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    public Vector2 enemyMovement;

    public bool canRun;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (canRun)
        {
            rb2D.velocity = enemyMovement * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
        {
            canRun = true;
        }
    }
}
