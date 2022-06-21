using UnityEngine;
namespace My2DPlatformer
{
    public sealed class ContactsPoller
    {
        private const float COLLISIONTRESHOLD = 0.1f;

        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        private Collider2D _collider;
        private Rigidbody2D _rigidbody;


        public bool IsGrounded { get; private set; }
        public bool HasLeftContacts { get; private set; }
        public bool HasRightContacts { get; private set; }
        public Vector2 GroundVelocity { get; private set; }

        public ContactsPoller(Collider2D collider, Rigidbody2D rigidbody)
        {
            _collider = collider;
            _rigidbody = rigidbody;
        }

        public void Update()
        {
            IsGrounded = false;
            HasLeftContacts = false;
            HasRightContacts = false;

            var contactsCount = _collider.GetContacts(_contacts);

            for (var i = 0; i < contactsCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidbody = _contacts[i].rigidbody;

                if (normal.y > COLLISIONTRESHOLD)
                {
                    IsGrounded = true;
                    GroundVelocity = _rigidbody.velocity;
                }

                if (normal.x > COLLISIONTRESHOLD && rigidbody == null)
                {
                    HasLeftContacts = true;
                }

                if (normal.x < -COLLISIONTRESHOLD && rigidbody == null)
                {
                    HasRightContacts = true;
                }
            }
        }
    }
}