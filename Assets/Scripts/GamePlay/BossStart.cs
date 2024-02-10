using UnityEngine;

namespace GamePlay
{
    public class BossStart : MonoBehaviour
    {

        [SerializeField] private GameObject initBoss;
        
        //Me quiero morir
        [SerializeField] private GameObject[] platformsWithEnemiesjif;


        public void BossPhaseInit()
        {
            Instantiate(initBoss, transform.position, Quaternion.identity);
            foreach (var p in platformsWithEnemiesjif)
            {
                Destroy(p.gameObject);
            }
        }
    }
}
