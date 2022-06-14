using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private SpriteRenderer _background;

        [SerializeField]
        private CharacterView _characterView;

        [SerializeField]
        private CannonView _cannonView;

        [SerializeField]
        private List<BulletView> _bullets;

        private SpriteAnimationsConfig _playerConfig;
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimator;
        private MainHeroWalker _mainHeroWalker;
        private AimingBarrel _aimingBarrel;
        private BulletEmitter _bulletEmitter;

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_camera.transform, _background.transform);
            _playerConfig = Resources.Load<SpriteAnimationsConfig>("PlayerSpriteAnimationsConfig");
            _spriteAnimator = new SpriteAnimator(_playerConfig);
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
            _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);
            _aimingBarrel = new AimingBarrel(_cannonView.BarrelTransform, _characterView.transform);
            _bulletEmitter = new BulletEmitter(_bullets, _cannonView.BulletEmitterTransform);
        }

        private void Update()
        {
            _paralaxManager.Update();
            _spriteAnimator.Update();
            _mainHeroWalker.Update();
            _aimingBarrel.Update();
            _bulletEmitter.Update();
        }
    }
}