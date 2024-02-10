using UnityEngine;

namespace GamePlay
{
    public class BossStart : MonoBehaviour
    {

        [SerializeField] private GameObject initBoss;


        public void BossPhaseInit()
        {
            Instantiate(initBoss, transform.position, Quaternion.identity);
        }
    }
}
