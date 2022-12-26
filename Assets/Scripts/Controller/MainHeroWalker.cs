using UnityEngine;
namespace PlatformerMVC
{
    public sealed class MainHeroWalker
    {
        private const float _walkSpeed = 2f;
        private const float _liesSpeed = 1f;
        private const float _animationsSpeed = 10f;
        private const float _jumpStartSpeed = 5f;
        private const float _movingThresh = 0.1f;
        private const float _flyThresh = 1f;
        private const float _groundLevel = 0.5f;
        private const float _g = -10f;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private float _yVelocity;
        private bool _doJump;
        private bool _do—rawl;
        private float _xAxisInput;
        private LevelObjectView _view;
        private SpriteAnimator _spriteAnimator;
        public MainHeroWalker(LevelObjectView view)
        {
            _view = view;
            SpriteAnimationsConfig config = Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");
            _spriteAnimator = new SpriteAnimator(config);
            _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.walk, true, _animationsSpeed);
        }
        public void Update()
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _do—rawl = Input.GetAxis("Vertical") < 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;
            if (IsGrounded())
            {
                //walking
                if (goSideWay) GoSideWay();
                if (_do—rawl) 
                {
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.Òrawl, true, _animationsSpeed);
                }
                else
                {
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, goSideWay ? Track.walk : Track.idle, true, _animationsSpeed);
                    //start jump
                    if (_doJump && _yVelocity == 0)
                    {
                        _yVelocity = _jumpStartSpeed;
                    }
                    //stop jump
                    else if (_yVelocity < 0)
                    {
                        _yVelocity = 0;
                        _view.Transform.position = _view.Transform.position.Change(y: _groundLevel);
                    }
                }
            }
            else
            {
                //flying
                if (goSideWay) GoSideWay();
                if (Mathf.Abs(_yVelocity) > _flyThresh)
                {
                    _spriteAnimator.StartAnimation(_view.SpriteRenderer, Track.jump, true, _animationsSpeed);
                }
                _yVelocity += _g * Time.deltaTime;
                _view.Transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
            _spriteAnimator.Update();
        }
        private void GoSideWay()
        {
            _view.Transform.position += Vector3.right * (Time.deltaTime * (_do—rawl ? _liesSpeed : _walkSpeed) * (_xAxisInput < 0 ? -1 : 1));
            _view.Transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }
        public bool IsGrounded()
        {
            return _view.Transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }
        public void OnDestroy()
        {
            _spriteAnimator.Dispose();
        }
    }
}