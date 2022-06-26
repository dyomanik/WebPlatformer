using UnityEngine;
namespace My2DPlatformer
{
    public class SimplePatrolAI
    {
        private readonly EnemyView _view;
        private readonly SimplePatrolAIModel _model;

        public SimplePatrolAI(EnemyView view, SimplePatrolAIModel model)
        {
            _view = view;
            _model = model;
        }

        public void FixedUpdate()
        {
            _view.Rigidbody.velocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
            if (_view.Rigidbody.velocity.x > 0)
            {
                _view.SpriteRenderer.flipX = false;
            }
            else
            {
                _view.SpriteRenderer.flipX = true;
            }
        }
    }
}