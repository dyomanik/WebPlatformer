using UnityEngine;
namespace My2DPlatformer 
{
    public sealed class DiverseGroundView : MonoBehaviour
    {
        [SerializeField]
        private Transform _StartTransform;

        [SerializeField]
        private Vector3 _startPosition;

        public Vector3 StartPosition => _startPosition;
        public Transform StartTransform => _StartTransform;
    }
}