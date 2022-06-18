using UnityEngine;
namespace My2DPlatformer
{
    public sealed class AimingBarrel
    {
        private Transform _barrelTransform;
        private Transform _aimTransform;
        private float _bulletSpeed = 15f;
        private float _freeFallAcceleration = 10f;
        private float? _alphaMinAngle = null;

        public AimingBarrel(Transform barrelTransform, Transform aimTransform)
        {
            _barrelTransform = barrelTransform;
            _aimTransform = aimTransform;

        }

        public void Update()
        {
            RotateBarrel();
        }

        private void RotateBarrel()
        {
            var direction = _barrelTransform.position - _aimTransform.position;
            float y = direction.y;
            direction.y = 0f;
            float x = direction.magnitude;

            float Speed2 = _bulletSpeed * _bulletSpeed;
            float Speed4 = _bulletSpeed * _bulletSpeed * _bulletSpeed * _bulletSpeed;
            float underTheRoot = Speed4 - _freeFallAcceleration * (_freeFallAcceleration * x * x + 2 * y * Speed2);

            if (underTheRoot > 0f)
            {
                float TheRoot = Mathf.Sqrt(underTheRoot);
                float numerator = Speed2 + TheRoot;
                float denominator = _freeFallAcceleration * x;
                _alphaMinAngle = Mathf.Atan2(numerator, denominator) * Mathf.Rad2Deg;
            }
            else
            {
                _alphaMinAngle = 45 * Mathf.Rad2Deg;
            }

            if (_alphaMinAngle != null)
            {
                float angle = (float)_alphaMinAngle;
                var axis = Vector3.Cross(Vector3.down, direction);
                _barrelTransform.rotation = Quaternion.AngleAxis(angle, axis);
            }
        }
    }
}