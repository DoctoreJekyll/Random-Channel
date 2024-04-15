using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7) //floor y hole
        {
            collision.gameObject.SetActive(false);

            FloorSpawner.floorSpawnerInstance.AddToFloorArray(collision.gameObject);
        }
        else if (collision.gameObject.layer == 9) //Plataforma
        {
            collision.gameObject.SetActive(false);

            PlatformSpawner.platformSpawnerInstance.AddToPlatformArray(collision.gameObject);
        }
        else if (collision.gameObject.layer == 10) //PopCorn
        {
            if (!collision.gameObject.GetComponent<PopCorn>().isDestruible)
                collision.gameObject.SetActive(false);
            else
                Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 11) //Enemigos
        {
            if (collision.gameObject.GetComponent<EnemyMovement>() != null)//Por si es un proyectil
            {
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyMovement>().canRun = false;
                collision.gameObject.SetActive(false);
            }
        }
    }
}
