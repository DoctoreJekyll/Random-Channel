using System;
using UnityEngine;

namespace GamePlay
{
    public class Projectile : MonoBehaviour
    {

        private Rigidbody2D rb2d;
        
        [SerializeField] private float direction;
        [SerializeField] private float speed;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Destroy(this.gameObject, 5f);
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
