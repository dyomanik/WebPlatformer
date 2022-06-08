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

        private SpriteAnimationsConfig _playerConfig;
        private ParalaxManager _paralaxManager;
        private SpriteAnimator _spriteAnimator;
        //[SerializeField]
        //private SomeView _someView;
        //add links to test views <1>
        //private SomeManager _someManager;
        //add links to some logic managers <2>

        private void Start()
        {
            //SomeConfig config = Resources.Load("SomeConfig",
            //typeof(SomeConfig)) as SomeConfig;
            //load some configs here <3>
            //_someManager = new SomeManager(config);
            //create some logic managers here for tests <4>
            _paralaxManager = new ParalaxManager(_camera.transform, _background.transform);
            _playerConfig = Resources.Load<SpriteAnimationsConfig>("PlayerSpriteAnimationsConfig");
            _spriteAnimator = new SpriteAnimator(_playerConfig);
            _spriteAnimator.StartAnimation(_characterView.spriteRenderer, Track.walk, true, 10);
        }
        private void Update()
        {
            //_someManager.Update();
            //update logic managers here <5>
            _paralaxManager.Update();
            _spriteAnimator.Update();
        }
        private void FixedUpdate()
        {
            //_someManager.FixedUpdate();
            //update logic managers here <6>
        }
        private void OnDestroy()
        {
            //_someManager.Dispose();
            //dispose logic managers here <7>
        }
    }
}