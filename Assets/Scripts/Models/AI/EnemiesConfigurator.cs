using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
namespace My2DPlatformer {
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private EnemyView _simplePatrolAIView;

        [Header("Stalker AI")]
        [SerializeField] private AIConfig _stalkerAIConfig;
        [SerializeField] private EnemyView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("Protector AI")]
        [SerializeField] private EnemyView _protectorAIView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;

        private SimplePatrolAI _simplePatrolAI;
        private StalkerAI _stalkerAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        private SpriteAnimationsConfig _simpleEnemyConfig;
        private SpriteAnimationsConfig _stalkerEnemyConfig;
        private SpriteAnimationsConfig _protectorEnemyConfig;
        private SpriteAnimator _simpleEnemyAnimator;
        private SpriteAnimator _stalkerEnemyAnimator;
        private SpriteAnimator _protectorEnemyAnimator;
        private readonly int _speedSimpleEnemy = 10;
        private readonly int _speedStalkerEnemy = 5;
        private readonly int _speedProtectorEnemy = 5;

        private void Start()
        {
            _simpleEnemyConfig = Resources.Load<SpriteAnimationsConfig>("DemonSpriteAnimationsConfig");
            _stalkerEnemyConfig = Resources.Load<SpriteAnimationsConfig>("JinSpriteAnimationsConfig");
            _protectorEnemyConfig = Resources.Load<SpriteAnimationsConfig>("JinSpriteAnimationsConfig");
            _simpleEnemyAnimator = new SpriteAnimator(_simpleEnemyConfig);
            _stalkerEnemyAnimator = new SpriteAnimator(_stalkerEnemyConfig);
            _protectorEnemyAnimator = new SpriteAnimator(_protectorEnemyConfig);
            _simpleEnemyAnimator.StartAnimation(_simplePatrolAIView.SpriteRenderer, Track.walk, true, _speedSimpleEnemy);
            _stalkerEnemyAnimator.StartAnimation(_stalkerAIView.SpriteRenderer, Track.walk, true, _speedStalkerEnemy);
            _protectorEnemyAnimator.StartAnimation(_protectorAIView.SpriteRenderer, Track.walk, true, _speedProtectorEnemy);

            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolAIModel(_simplePatrolAIConfig));
            _stalkerAI = new StalkerAI(_stalkerAIView, new StalkerAIModel(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            _protectorAI = new ProtectorAI(_protectorAIView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
            _protectorAI.Init();
            _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
            _protectedZone.Init();
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
        }
        private void FixedUpdate()
        {
            if (_simplePatrolAI != null)
            {
                _simplePatrolAI.FixedUpdate();
            } 
                
            if (_stalkerAI != null)
            {
                _stalkerAI.FixedUpdate();
            }   
        }

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }

        private void Update()
        {
            _simpleEnemyAnimator.Update();
            _stalkerEnemyAnimator.Update();
            _protectorEnemyAnimator.Update();
        }

        private void OnDestroy()
        {
            _protectorAI.Deinit();
            _protectedZone.Deinit();
        }

    }
}