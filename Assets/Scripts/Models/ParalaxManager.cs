using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public sealed class ParalaxManager
    {
        private readonly Vector2 BACKGROUND_COEFFICIENT = new Vector2(0.05f,0.025f);
        private const float FOREGROUND_COEFFICIENT = -0.1f;
        private Transform _camera;
        private List<DiverseGroundView> _backgrounds;
        private List<DiverseGroundView> _foregrounds;
        
        private Vector3 _cameraStartPosition;
        
        public ParalaxManager(Transform camera, List<DiverseGroundView> backgrounds, List<DiverseGroundView> foregrounds)
        {
            _camera = camera;
            _cameraStartPosition = _camera.transform.position;
            _backgrounds = backgrounds;
            _foregrounds = foregrounds;
        }
        public void Update()
        {
            for (int i = 0; i < _foregrounds.Count; i++)
            {
                _foregrounds[i].StartTransform.position = _foregrounds[i].StartPosition + (_camera.position - _cameraStartPosition) * FOREGROUND_COEFFICIENT;
            }

            for (int i = 0; i < _backgrounds.Count; i++)
            {
                _backgrounds[i].StartTransform.position = _backgrounds[i].transform.position.Change(x: _backgrounds[i].StartPosition.x + (_camera.position.x - _cameraStartPosition.x) * BACKGROUND_COEFFICIENT.x, 
                        y: _backgrounds[i].StartPosition.y + (_camera.position.y - _cameraStartPosition.y) * BACKGROUND_COEFFICIENT.y);
            }
        }
    }
}