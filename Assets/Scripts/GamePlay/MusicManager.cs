using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManagerInstance;

    [SerializeField] AudioSource source;


    // Start is called before the first frame update
    void Awake()
    {
        musicManagerInstance = this;
    }

    public void PlayFxSound(AudioClip clip)
    {
        source.PlayOneShot(clip, 1f);
    } 
}
