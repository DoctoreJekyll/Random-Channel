using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float scrollVelocity;
    [SerializeField] Renderer rendererM;

    [SerializeField] bool isStopParallax;
    [SerializeField] float counterTime;
       
    // Update is called once per frame
    void Update()
    {
        if (!isStopParallax)
        {
            counterTime += Time.deltaTime;
            rendererM.material.mainTextureOffset = new Vector2(((counterTime/*Time.time*/) * scrollVelocity) % 1, 0);
        }       
    }

    public void ChangeParallaxState(bool b)
    {
        isStopParallax = b;
    }
}
