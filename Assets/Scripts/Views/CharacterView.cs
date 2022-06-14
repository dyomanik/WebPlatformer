using UnityEngine;
namespace My2DPlatformer
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [Header("Settings")]
        [SerializeField]
        private float _walkSpeed = 4f;

        [SerializeField]
        private float _animationsSpeed = 20f;

        [SerializeField]
        private float _jumpStartSpeed = 5f;

        [SerializeField]
        private float _movingThreshold = 0.1f;

        [SerializeField]
        private float _flyThreshold = 0.4f;

        [SerializeField]
        private float _groundLevel = -2.92f;

        [SerializeField]
        private float _freeFallAcceleration = -10f;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public float WalkSpeed => _walkSpeed;

        public float AnimationSpeed => _animationsSpeed;

        public float JumpStartSpeed => _jumpStartSpeed;

        public float MovingThreshold => _movingThreshold;

        public float FlyThreshold => _flyThreshold;

        public float GroundLevel => _groundLevel;

        public float FreeFallAcceleration => _freeFallAcceleration;
    }
}