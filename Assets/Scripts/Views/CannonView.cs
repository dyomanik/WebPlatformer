using UnityEngine;
namespace My2DPlatformer
{
    public sealed class CannonView : MonoBehaviour
    {
        [SerializeField]
        private Transform _barrelTransform;
        [SerializeField]
        private Transform _bulletEmitterTransform;

        public Transform BarrelTransform => _barrelTransform;

        public Transform BulletEmitterTransform => _bulletEmitterTransform;
    }
}