using System;
using UnityEngine;
using Pathfinding;
namespace My2DPlatformer {
    public class StalkerAI
    {
        private readonly EnemyView _view;
        private readonly StalkerAIModel _model;
        private readonly Seeker _seeker;
        private readonly Transform _target;

        public StalkerAI(EnemyView view, StalkerAIModel model, Seeker seeker, Transform target)
        {
            _view = view;
            _model = model;
            _seeker = seeker;
            _target = target;
        }

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody.velocity = newVelocity;
            _view.SpriteRenderer.flipX = _view.Rigidbody.velocity.x < 0;
        }
        public void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_view.Rigidbody.position, _target.position, OnPathComplete);
            }
        }
        private void OnPathComplete(Path path)
        {
            if (path.error) return;
            _model.UpdatePath(path);
        }

    }
}