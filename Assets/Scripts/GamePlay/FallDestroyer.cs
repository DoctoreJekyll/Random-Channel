using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroyer : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameOverManager.gameOverManagerInstance.InitializeGameOver(false);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == 11)
            collision.gameObject.SetActive(false);
    }   
}
