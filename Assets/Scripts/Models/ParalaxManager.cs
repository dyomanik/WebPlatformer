using UnityEngine;
namespace My2DPlatformer
{
    public sealed class ParalaxManager
    {
        private const float BACKGROUND_COEFFICIENT = 0.3f;
        private Transform _camera;
        private Transform _background;
        private Vector3 _backgroundStartPosition;
        private Vector3 _cameraStartPosition;
        
        public ParalaxManager(Transform camera, Transform background)
        {
            _camera = camera;
            _background = background;
            _backgroundStartPosition = _background.transform.position;
            _cameraStartPosition = _camera.transform.position;
        }
        public void Update()
        {
            _background.position = _backgroundStartPosition + (_camera.position - _cameraStartPosition) * BACKGROUND_COEFFICIENT;
        }
    }
}