using System.Collections;
using System.Collections.Generic;
using GamePlay.Boss;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.CallDeadMoment();
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
