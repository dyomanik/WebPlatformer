using System;
using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer 
{
    public class LevelCompleteManager : IDisposable
    {
        private Vector3 _startPosition;
        private CharacterView _characterView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteManager(CharacterView characterView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _startPosition = characterView.Transform.position;
            _characterView = characterView;
            _characterView.LevelObjectViewContact += OnLevelObjectContact;
            _characterView.BulletContact += BulletContact;
            _characterView.TrapViewContact += TrapContact;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _characterView.Transform.position = _startPosition;
            }
            if (_winZones.Contains(contactView))
            {
                Debug.Log("You Win!");
            }
        }

        private void BulletContact(BulletView bulletView, int damage)
        {
            if (_characterView.Lifes > 0)
            {
                bulletView.gameObject.SetActive(false);
                _characterView.Lifes-= damage;
                if (_characterView.Lifes <= 0)
                {
                    _characterView.Transform.position = _startPosition;
                    _characterView.Lifes = 3;
                }
            }
        }

        private void TrapContact(TrapView trapView, int damage)
        {
            if (_characterView.Lifes > 0)
            {
                _characterView.Lifes -= damage;
                _characterView.Rigidbody.AddForce(Vector2.up * _characterView.JumpForce);
                Debug.LogError("Contact");
                if (_characterView.Lifes <= 0)
                {
                    _characterView.Transform.position = _startPosition;
                    _characterView.Lifes = 3;
                }
            }
        }

        public void Dispose()
        {
            _characterView.LevelObjectViewContact -= OnLevelObjectContact;
            _characterView.BulletContact -= BulletContact;
            _characterView.TrapViewContact -= TrapContact;
        }
    }
}