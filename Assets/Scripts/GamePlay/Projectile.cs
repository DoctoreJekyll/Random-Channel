using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePlay
{
    public class Projectile : MonoBehaviour
    {

        private Rigidbody2D rb2d;
        
        [SerializeField] private float direction;
        [SerializeField] private float speed;

        [SerializeField] private bool canRotate;
        [SerializeField] private float rotationSpeed;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            if (canRotate)
            {
                transform.Rotate(0f, 0f, Random.Range(0f, 360f));
            }
            
        }

        private void Start()
        {
            Destroy(this.gameObject, 8f);
        }

        private void Update()
        {
            if (canRotate)
            {
                var rotation = transform.rotation;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotation.eulerAngles.z + 50f * Time.deltaTime);
                rotation = Quaternion.Lerp(rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.rotation = rotation;
            }
        }

        private void FixedUpdate()
        {
            rb2d.velocity = Direction() * speed;
        }

        private Vector2 Direction()
        {
            return Vector2.right * direction;
        }
    }
}
