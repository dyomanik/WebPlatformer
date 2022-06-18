using System;
using UnityEngine;
namespace My2DPlatformer
{
    public sealed class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private Collider2D _collider;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [Header("Settings")]
        [SerializeField]
        private float _walkSpeed = 250f;

        [SerializeField]
        private float _animationsSpeed = 20f;

        [SerializeField]
        private float _jumpStartSpeed = 700f;

        [SerializeField]
        private float _movingThreshold = 0.1f;

        [SerializeField]
        private float _flyThreshold = 0.4f;

        [SerializeField]
        private float _groundLevel = -2.92f;

        [SerializeField]
        private float _freeFallAcceleration = -10f;

        [SerializeField]
        private int _lifes = 3;

        public Action<LevelObjectView> LevelObjectViewContact { get; set; }
        public Action<BulletView, int> BulletContact { get; set; }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public float WalkSpeed => _walkSpeed;

        public float AnimationSpeed => _animationsSpeed;

        public float JumpStartSpeed => _jumpStartSpeed;

        public float MovingThreshold => _movingThreshold;

        public float FlyThreshold => _flyThreshold;

        public float GroundLevel => _groundLevel;

        public float FreeFallAcceleration => _freeFallAcceleration;

        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody => _rigidbody;

        public Collider2D Collider => _collider;

        public int Lifes { get => _lifes; set => _lifes = value; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<LevelObjectView>(out var levelObjectView))
            {
                LevelObjectViewContact?.Invoke(levelObjectView);
            }

            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<BulletView>(out var bulletView))
            {
                if (collision.otherCollider is CapsuleCollider2D)
                {
                    BulletContact?.Invoke(bulletView, 3);
                }
                else BulletContact?.Invoke(bulletView, 1);
            }
            
        }


    }
}