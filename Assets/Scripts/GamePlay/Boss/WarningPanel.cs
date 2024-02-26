using System;
using System.Collections;
using UnityEngine;

namespace GamePlay.Boss
{
    public class WarningPanel : MonoBehaviour
    {
        [SerializeField] private float timeToBossSpawn;
        
        private void OnEnable()
        {
            StartCoroutine(WarningAnim());
        }

        private IEnumerator WarningAnim()
        {
            yield return new WaitForSeconds(timeToBossSpawn);
            this.gameObject.SetActive(false);
            
        }
    }
}
