using UnityEngine;
namespace My2DPlatformer
{
    public sealed class PhysicsBullet
    {
        private BulletView _bulletView;
        public PhysicsBullet(BulletView view)
        {
            _bulletView = view;
            _bulletView.SetVisible(false);
        }
        public void Throw(Vector3 position, Vector3 velocity)
        {
            _bulletView.SetInteractive(true);
            _bulletView.Transform.position = position;
            _bulletView.Rigidbody.velocity = Vector2.zero;
            _bulletView.Rigidbody.angularVelocity = 0;
            _bulletView.Rigidbody.AddForce(velocity, ForceMode2D.Impulse);
            _bulletView.SetVisible(true);
        }
    }
}