using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public sealed class ParalaxManager
    {
        private readonly Vector2 BACKGROUND_COEFFICIENT = new Vector2(0.05f,0.025f);
        private const float FOREGROUND_COEFFICIENT = -0.1f;
        private Transform _camera;
        private List<Transform> _backgroundTransforms;
        private List<Vector3> _backgroundStartPositions;
        private List<Transform> _foregroundTransforms;
        private List<Vector3> _foregroundStartPositions;
        private Vector3 _cameraStartPosition;
        
        public ParalaxManager(Transform camera, List<Transform> backgroundTransforms, List<Transform> foregroundTransforms)
        {
            _camera = camera;
            _foregroundTransforms = new List<Transform>();
            _foregroundStartPositions = new List<Vector3>();

            _backgroundTransforms = new List<Transform>();
            _backgroundStartPositions = new List<Vector3>();

            _foregroundTransforms = foregroundTransforms;
            _backgroundTransforms = backgroundTransforms;

            foreach (Transform foregroundTransform in _foregroundTransforms)
            {
                _foregroundStartPositions.Add(foregroundTransform.position);
                
            }

            foreach (Transform backgroundTransform in _backgroundTransforms)
            {
                _backgroundStartPositions.Add(backgroundTransform.position);
            }

            _cameraStartPosition = _camera.transform.position;
        }
        public void Update()
        {
            for (int i = 0; i < _foregroundTransforms.Count; i++)
            {
                for (int j = 0; j < _foregroundStartPositions.Count; j++)
                {
                    _foregroundTransforms[i].position = _foregroundStartPositions[j] + (_camera.position - _cameraStartPosition) * FOREGROUND_COEFFICIENT;
                }
            }

            for (int i = 0; i < _backgroundTransforms.Count; i++)
            {
                    _backgroundTransforms[i].position = _backgroundTransforms[i].position.Change(x: _backgroundStartPositions[i].x + (_camera.position.x - _cameraStartPosition.x) * BACKGROUND_COEFFICIENT.x, 
                        y: _backgroundStartPositions[i].y + (_camera.position.y - _cameraStartPosition.y) * BACKGROUND_COEFFICIENT.y);
            }
        }
    }
}