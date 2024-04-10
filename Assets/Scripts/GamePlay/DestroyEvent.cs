using UnityEngine;

namespace GamePlay
{
    public class DestroyEvent : MonoBehaviour
    {

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }
    
    
    
    }
}
