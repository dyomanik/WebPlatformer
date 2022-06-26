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
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
            _seeker = seeker != null ? seeker : throw new ArgumentNullException(nameof(seeker));
            _target = target != null ? target : throw new ArgumentNullException(nameof(target));
        }

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody.velocity = newVelocity;
            if (_view.Rigidbody.velocity.x > 0)
            {
                _view.SpriteRenderer.flipX = false;
            }
            else
            {
                _view.SpriteRenderer.flipX = true;
            }
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