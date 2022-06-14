using UnityEngine;
namespace My2DPlatformer
{
    public class MainHeroWalker
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        private float _yVelocity;

        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;
        private float _xAxisInput;
        private float _distanceOfDash = 3f;
        private float _timeOfDash = 0.8f;
        private float _timer;
        private bool _IsDoingJump;
        private bool _IsDoingDash;
        private Vector3 _positionAfterDash;

        public MainHeroWalker(CharacterView CharacterView, SpriteAnimator spriteAnimator)
        {
            _characterView = CharacterView;
            _spriteAnimator = spriteAnimator;
        }

        public void Update()
        {
            GetInput(Horizontal, Vertical);

            var isMove = Mathf.Abs(_xAxisInput) > _characterView.MovingThreshold;

            if (isMove)
            {
                Move(_xAxisInput);
            }

            if (isGrounded() && !_IsDoingDash)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isMove ? Track.walk : Track.idle, true, _characterView.AnimationSpeed);

                if (_IsDoingJump && Mathf.Approximately(_yVelocity, 0))
                {
                    _yVelocity = _characterView.JumpStartSpeed;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    Grounding();
                }
            }
            else if (isGrounded() && _IsDoingDash)
            {
                Dash();
            }
            else
            {
                Jump();
            }

        }

        private void Jump()
        {
            _yVelocity += _characterView.FreeFallAcceleration * Time.deltaTime;

            if(Mathf.Abs(_yVelocity) > _characterView.FlyThreshold)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump, false, _characterView.AnimationSpeed);
            }

            _characterView.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
        }

        private void Grounding()
        {
            _characterView.transform.position = _characterView.transform.position.Change(y: _characterView.GroundLevel);
        }

        private bool isGrounded()
        {
            return _characterView.transform.position.y <= _characterView.GroundLevel && _yVelocity <= 0;
        }

        private void Move(float xAxisInput)
        {
            _characterView.transform.position += Vector3.right * (Time.deltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1));
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;
        }

        private void GetInput(string xAxis, string yAxis)
        {
            _IsDoingJump = Input.GetAxis(yAxis) > 0;
            _xAxisInput = Input.GetAxis(xAxis);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                _positionAfterDash = _characterView.transform.position.Change(x: _characterView.transform.position.x + (_characterView.SpriteRenderer.flipX ? -1 : 1) * _distanceOfDash);
                _IsDoingDash = true;
            }
        }

        private void Dash()
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.dash, false, _characterView.AnimationSpeed);
            var step = _distanceOfDash * Time.deltaTime;
            _timer += Time.deltaTime;
            _characterView.transform.position = Vector3.MoveTowards(_characterView.transform.position, _positionAfterDash, step);

            if (_timer > _timeOfDash)
            {
                _IsDoingDash = false;
                _timer = 0;
            }
        }
    }
}