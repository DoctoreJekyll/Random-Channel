using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            GameOverManager.gameOverManagerInstance.InitializeGameOver(true);
        }
        else if(collision.gameObject.layer == 10)
        {
            if (collision.gameObject.GetComponent<PopCorn>().isDestruible)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
