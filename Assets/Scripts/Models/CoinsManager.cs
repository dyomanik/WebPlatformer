using System;
using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public class CoinsManager : IDisposable
    {
        private const float _animationsSpeed = 20f;
        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;
        private List<LevelObjectView> _coinViews;
        public CoinsManager(CharacterView characterView, List<LevelObjectView> coinViews, SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;
            _coinViews = coinViews;
            _characterView.LevelObjectViewContact += OnLevelObjectContact;
            foreach (var coinView in coinViews)
            {
               _spriteAnimator.StartAnimation(coinView.SpriteRenderer, Track.coinRotation, true, _animationsSpeed);
            }
        }
        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }
        public void Dispose()
        {
            _characterView.LevelObjectViewContact -= OnLevelObjectContact;
        }
    }
}