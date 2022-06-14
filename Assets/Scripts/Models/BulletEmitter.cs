using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public class BulletEmitter
    {
        private const float _delay = 3;
        private const float _bulletSpeed = 10;

        private List<Bullet> _bullets = new List<Bullet>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletEmitter(List<BulletView> bulletViews, Transform transformOfEmitter)
        {
            _transform = transformOfEmitter;

            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new Bullet(bulletView));
            }
        }

        public void Update()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, _transform.up * _bulletSpeed);
                _currentIndex++;

                if (_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0;
                }
            }

            _bullets.ForEach(b => b.Update());
        }

    }
}