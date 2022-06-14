using UnityEngine;
namespace My2DPlatformer
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [Header("Settings")]

        [SerializeField]
        private float _radius = 0.3f;

        [SerializeField]
        private float _groundLevel = -4.2f;

        [SerializeField]
        private float _freeFallAcceleration = -10;

        [SerializeField]
        private TrailRenderer _trail;

        public float Radius => _radius;

        public float GroundLevel => _groundLevel;

        public float FreeFallAcceleration => _freeFallAcceleration;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            _spriteRenderer.enabled = visible;
        }
    }
}