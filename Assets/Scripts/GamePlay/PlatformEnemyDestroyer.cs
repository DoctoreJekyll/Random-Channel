using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemyDestroyer : MonoBehaviour
{
    [SerializeField] bool canDesactiveEnemies;


    private void OnEnable()
    {
        canDesactiveEnemies = true;
        StartCoroutine(DesactiveEffectCoroutine());
    }

    IEnumerator DesactiveEffectCoroutine()
    {
        yield return new WaitForSeconds(3f);
        canDesactiveEnemies = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11 && canDesactiveEnemies) //Enemigos
        {
            Debug.Log("Plataforma destruyo enemigo", collision.gameObject);

            if (collision.gameObject.GetComponent<EnemyMovement>() != null)
            {
                collision.gameObject.GetComponent<EnemyMovement>().canRun = false;
            }

            collision.gameObject.SetActive(false);
        }
    }
}
