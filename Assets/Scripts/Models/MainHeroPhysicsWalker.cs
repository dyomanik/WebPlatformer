using UnityEngine;
namespace My2DPlatformer
{
    public sealed class MainHeroPhysicsWalker
    {
        private const string Horizontal = nameof(Horizontal);
        private const string Vertical = nameof(Vertical);

        private CharacterView _characterView;
        private SpriteAnimator _spriteAnimator;
        private ContactsPoller _contactsPoller;

        private float _xAxisInput;
        private float _distanceOfDash = 3f;
        private float _timeOfDash = 1f;
        private float _timer;
        private bool _isDoingJump;
        private bool _isDoingDash;
        private Vector2 _positionAfterDash;

        public MainHeroPhysicsWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
        {
            _characterView = characterView;
            _spriteAnimator = spriteAnimator;

            _contactsPoller = new ContactsPoller(characterView.Collider);
        }

        public void Update()
        {
            GetInput();
        }

        public void FixedUpdate()
        {
            _contactsPoller.Update();

            var isMove = Mathf.Abs(_xAxisInput) > _characterView.MovingThreshold;

            if (isMove)
            {
                Move(isMove);
            }

            if (_contactsPoller.IsGrounded && _isDoingJump && Mathf.Abs(_characterView.Rigidbody.velocity.y) <= _characterView.FlyThreshold)
            {
                _characterView.Rigidbody.AddForce(Vector2.up * _characterView.JumpStartSpeed);
            }

            if (_contactsPoller.IsGrounded && !_isDoingDash)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isMove ? Track.walk : Track.idle, true, _characterView.AnimationSpeed);
            }
            else if (Mathf.Abs(_characterView.Rigidbody.velocity.y) > _characterView.FlyThreshold)
            {
                _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump, false, _characterView.AnimationSpeed);
            }
            else if (_contactsPoller.IsGrounded && _isDoingDash)
            {
                Dash();
            }
        }

        private void GetInput()
        {
            _isDoingJump = Input.GetAxis(Vertical) > 0;
            _xAxisInput = Input.GetAxis(Horizontal);

            if (Input.GetKeyDown(KeyCode.Space) && _contactsPoller.IsGrounded)
            {
                _positionAfterDash = _characterView.Rigidbody.position.Change(x: _characterView.Rigidbody.position.x + (_characterView.SpriteRenderer.flipX ? -1 : 1) * _distanceOfDash);
                _isDoingDash = true;
            }
        }

        private void Move(bool isMove)
        {
            _characterView.SpriteRenderer.flipX = _xAxisInput < 0;
            
            var newVelocity = 0f;

            if (isMove && (_xAxisInput > 0 || !_contactsPoller.HasLeftContacts) && (_xAxisInput < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = Time.fixedDeltaTime * _characterView.WalkSpeed * (_xAxisInput < 0 ? -1 : 1);
            }

            _characterView.Rigidbody.velocity = _characterView.Rigidbody.velocity.Change(x: newVelocity);
        }

        private void Dash()
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.dash, false, _characterView.AnimationSpeed);
            _timer += Time.fixedDeltaTime;
            _characterView.Rigidbody.MovePosition(_positionAfterDash);

            if (_timer > _timeOfDash || Mathf.Approximately(_characterView.Rigidbody.position.y, _positionAfterDash.y))
            {
                _isDoingDash = false;
                _timer = 0;
            }
        }

    }
}