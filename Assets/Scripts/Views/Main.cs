using System.Collections.Generic;
using UnityEngine;
namespace My2DPlatformer
{
    public sealed class Main : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private List<DiverseGroundView> _backgrounds;

        [SerializeField]
        private List<DiverseGroundView> _foregrounds;

        [SerializeField]
        private CharacterView _characterView;

        [SerializeField]
        private CannonView _cannonView;

        [SerializeField]
        private List<BulletView> _bullets;

        [SerializeField]
        private List<LevelObjectView> _coins;

        [SerializeField]
        private List<LevelObjectView> _deathZones;

        [SerializeField]
        private List<LevelObjectView> _winZone;

        [SerializeField]
        private List<LevelObjectView> _liftViews;

        [SerializeField]
        private List<LevelObjectView> _liftTriggers;

        private SpriteAnimationsConfig _playerConfig;
        private SpriteAnimationsConfig _coinsConfig;
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _playerSpriteAnimator;
        private SpriteAnimator _coinsSpriteAnimator;
        private MainHeroPhysicsWalker _mainHeroPhysicsWalker;
        private AimingBarrel _aimingBarrel;
        private BulletEmitter _bulletEmitter;
        private CoinsManager _coinsManager;
        private LevelCompleteManager _levelCompleteManager;
        private LiftsManager _liftsManager;
        

        private void Start()
        {
            _paralaxManager = new ParalaxManager(_camera.transform, _backgrounds, _foregrounds);
            

            _playerConfig = Resources.Load<SpriteAnimationsConfig>("PlayerSpriteAnimationsConfig");
            _coinsConfig = Resources.Load<SpriteAnimationsConfig>("StarSpriteAnimationsConfig");

            _playerSpriteAnimator = new SpriteAnimator(_playerConfig);
            _coinsSpriteAnimator = new SpriteAnimator(_coinsConfig);

            _playerSpriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.walk, true, 10);
            _mainHeroPhysicsWalker = new MainHeroPhysicsWalker(_characterView, _playerSpriteAnimator);

            _aimingBarrel = new AimingBarrel(_cannonView.BarrelTransform, _characterView.transform);
            _bulletEmitter = new BulletEmitter(_bullets, _cannonView.BulletEmitterTransform);
            
            _levelCompleteManager = new LevelCompleteManager(_characterView, _deathZones, _winZone);
            _liftsManager = new LiftsManager(_liftViews, _liftTriggers);
            _coinsManager = new CoinsManager(_characterView, _coins, _coinsSpriteAnimator);
        }

        private void Update()
        {
            _paralaxManager.Update();
            _playerSpriteAnimator.Update();
            _coinsSpriteAnimator.Update();
            _aimingBarrel.Update();
            _bulletEmitter.Update();
            _mainHeroPhysicsWalker.Update();
        }

        private void FixedUpdate()
        {
            _mainHeroPhysicsWalker.FixedUpdate();
        }
    }
}