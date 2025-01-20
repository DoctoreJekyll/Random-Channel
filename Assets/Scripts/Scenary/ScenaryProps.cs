using UnityEngine;

namespace Scenary
{
    public class ScenaryProps : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb2D;
        [SerializeField] Vector2 propMovement;

        public bool canRun;
        [SerializeField] float timeToDestroy;


        // Start is called before the first frame update
        void Start()
        {

        }
        

        private void FixedUpdate()
        {
            if (canRun)
            {
                rb2D.velocity = propMovement * Time.deltaTime;
            }
        }

        private void Update()
        {
            if (PlayerBeginGame.playerBeginGameInstance.gamePlayStart)
            {
                canRun = true;
            }
            
            if (canRun)
            {
                timeToDestroy -= Time.deltaTime;
                if (timeToDestroy <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
