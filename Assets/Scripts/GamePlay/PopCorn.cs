using System.Collections;
using System.Collections.Generic;
using Scenary;
using UnityEngine;

public class PopCorn : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] AudioClip[] clip;

    [SerializeField] Rigidbody2D rb2D;
    public Vector2 popCornMovement;

    public bool canRun, isDestruible;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (canRun)
        {
            rb2D.velocity = popCornMovement * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8 && !isDestruible)
        {
            int temp = Random.Range(0, clip.Length);

            ScoreManager.ScoreManagerInstance.AddPopCorn(points);
            MusicManager.musicManagerInstance.PlayFxSound(clip[temp]);
            BocadilloPool.bocadilloPoolInstance.GenerateBocadillo(transform);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == 8 && isDestruible)
        {
            ScoreManager.ScoreManagerInstance.AddPopCorn(points);
            MusicManager.musicManagerInstance.PlayFxSound(clip[0]);
            BocadilloPool.bocadilloPoolInstance.GenerateBocadillo(transform);
            Destroy(gameObject);
        }
    }
}
