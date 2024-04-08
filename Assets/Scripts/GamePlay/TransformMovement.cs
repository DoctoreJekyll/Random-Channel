using UnityEngine;

namespace GamePlay
{
    public class TransformMovement : MonoBehaviour
    {

        [SerializeField] private float direction;
        [SerializeField] private float speed;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(transform.right * (direction * speed * Time.deltaTime));
        }
    }
}
