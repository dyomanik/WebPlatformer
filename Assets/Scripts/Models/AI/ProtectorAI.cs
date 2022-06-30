using Pathfinding;
using UnityEngine;
namespace My2DPlatformer
{
    public class ProtectorAI : IProtector
    {
        private readonly EnemyView _enemyView;
        private readonly PatrolAIModel _model;
        private readonly AIDestinationSetter _destinationSetter;
        private readonly AIPatrolPath _patrolPath;

        private bool _isPatrolling;

        public ProtectorAI(EnemyView enemyView, PatrolAIModel model, AIDestinationSetter destinationSetter, AIPatrolPath patrolPath)
        {
            _enemyView = enemyView;
            _model = model;
            _destinationSetter = destinationSetter;
            _patrolPath = patrolPath;
        }

        public void Init()
        {
            _destinationSetter.target = _model.GetNextTarget();
            _isPatrolling = true;
            _patrolPath.TargetReached += OnTargetReached;
        }

        public void Deinit()
        {
            _patrolPath.TargetReached -= OnTargetReached;
        }

        private void OnTargetReached()
        {
            _destinationSetter.target = _isPatrolling? _model.GetNextTarget() : _model.GetClosestTarget(_enemyView.transform.position);
            _enemyView.SpriteRenderer.flipX = _destinationSetter.target.position.x < _enemyView.transform.position.x;
        }

        public void StartProtection(GameObject invader)
        {
            _isPatrolling = false;
            _destinationSetter.target = invader.transform;
            _enemyView.SpriteRenderer.flipX = _destinationSetter.target.position.x < _enemyView.transform.position.x;
        }

        public void FinishProtection(GameObject invader)
        {
            _isPatrolling = true;
            _destinationSetter.target = _model.GetClosestTarget(_enemyView.transform.position);
        }
    }
}