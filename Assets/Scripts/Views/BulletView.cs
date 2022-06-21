using UnityEngine;
namespace My2DPlatformer
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Collider2D _collider;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private TrailRenderer _trail;

        [Header("Settings")]

        [SerializeField]
        private float _radius = 0.3f;

        [SerializeField]
        private float _groundLevel = -4.2f;

        [SerializeField]
        private float _freeFallAcceleration = -10;

        public float Radius => _radius;

        public float GroundLevel => _groundLevel;

        public float FreeFallAcceleration => _freeFallAcceleration;

        public Collider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;

        public Transform Transform => _transform;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            _spriteRenderer.enabled = visible;
        }

        public void SetInteractive(bool interactive)
        {
            SetVisible(!interactive);
            gameObject.SetActive(interactive);
        }

    }
}