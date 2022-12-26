using UnityEngine;
namespace PlatformerMVC
{
    public sealed class PhysicsBullet
    {
        private BulletView _view;
        public PhysicsBullet(BulletView view)
        {
            _view = view;
            _view.SetVisible(false);
        }
        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.TrailRenderer.enabled = false;
            _view.SetVisible(false);
            _view.Transform.position = position;
            _view.Rigidbody2D.velocity = Vector2.zero;
            _view.Rigidbody2D.angularVelocity = 0;
            _view.SetVisible(true);
            _view.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
            _view.TrailRenderer.enabled = true;
        }
    }
}