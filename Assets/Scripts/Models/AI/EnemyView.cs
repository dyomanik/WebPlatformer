using UnityEngine;
namespace My2DPlatformer
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public Rigidbody2D Rigidbody => _rigidbody;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}