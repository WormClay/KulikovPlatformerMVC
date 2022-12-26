using UnityEngine;
namespace PlatformerMVC
{
    public sealed class MainHeroPhysicsWalker
    {
        private const string _verticalAxisName = "Vertical";
        private const string _horizontalAxisName = "Horizontal";
        private const float _animationsSpeed = 10;
        private const float _walkSpeed = 150;
        private const float _jumpForse = 350;
        private const float _jumpThresh = 0.1f;
        private const float _flyThresh = 1f;
        private const float _movingThresh = 0.1f;
        private bool _doJump;
        private float _goSideWay = 0;
        private readonly LevelObjectView _view;
        private readonly SpriteAnimator _spriteAnimator;
        private readonly ContactsPoller _contactsPoller;
        public MainHeroPhysicsWalker(LevelObjectView view)
        {
            _view = view;
            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");
            _spriteAnimator = new SpriteAnimator(config);
            _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.walk, true, _animationsSpeed);
            _contactsPoller = new ContactsPoller(_view.Collider2D);
        }
        public void FixedUpdate()
        {
            _doJump = Input.GetAxis(_verticalAxisName) > 0;
            _goSideWay = Input.GetAxis(_horizontalAxisName);
            _contactsPoller.Update();
            var walks = Mathf.Abs(_goSideWay) > _movingThresh;
            if (walks) _view.SpriteRenderer.flipX = _goSideWay < 0;
            var newVelocity = 0f;
            if (walks &&
            (_goSideWay > 0 || !_contactsPoller.HasLeftContacts) &&
            (_goSideWay < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = Time.fixedDeltaTime * _walkSpeed * (_goSideWay < 0 ? -1 : 1);
            }
            _view.Rigidbody2D.velocity = _view.Rigidbody2D.velocity.Change(x: newVelocity);
            if (_contactsPoller.IsGrounded && _doJump &&
            Mathf.Abs(_view.Rigidbody2D.velocity.y) <= _jumpThresh)
            {
                _view.Rigidbody2D.AddForce(Vector3.up * _jumpForse);
            }
            //animations
            if (_contactsPoller.IsGrounded)
            {
                var track = walks ? Track.walk : Track.idle;
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, track, true, _animationsSpeed);
            }
            else if (Mathf.Abs(_view.Rigidbody2D.velocity.y) > _flyThresh)
            {
                var track = Track.jump;
                _spriteAnimator.StartAnimation(_view.SpriteRenderer, track, true, _animationsSpeed);
            }
            _spriteAnimator.Update();
        }
    }
}
