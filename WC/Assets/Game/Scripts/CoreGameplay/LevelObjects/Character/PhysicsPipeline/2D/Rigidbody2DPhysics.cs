using UnityEngine;

namespace WC
{
    public class Rigidbody2DPhysics : Physics
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField, Min(0f)] private float _maxFallVelocity = 5f;

        private Vector2 _inheritedVelocityChange;
        private Vector2 _velocityChange;

        private Vector2 _lastInheritedVelocityChange;

        private Vector2 _expectedVelocity;

        public override Vector3 Velocity => _rigidbody2D.velocity - _lastInheritedVelocityChange;

        public override Vector3 Depenetration => _expectedVelocity - _rigidbody2D.velocity;

        public override Vector3 Position => _rigidbody2D.position;

        public override void AddInheritedForce(Vector3 velocity)
        {
            _inheritedVelocityChange += velocity.ToXY();
        }

        public override void AddForce(Vector3 velocity)
        {
            _velocityChange += velocity.ToXY();
        }

        public override void ApplyVelocityChanges()
        {
            Vector2 newInternalVelocity = Velocity.ToXY() + _velocityChange;

            newInternalVelocity = new Vector2(newInternalVelocity.x, Mathf.Max(newInternalVelocity.y, -_maxFallVelocity));

            Vector2 newAbsoluteVelocity = newInternalVelocity + _inheritedVelocityChange;

            _rigidbody2D.velocity = newAbsoluteVelocity;
            _expectedVelocity = newAbsoluteVelocity;

            _lastInheritedVelocityChange = _inheritedVelocityChange;

            _velocityChange = Vector2.zero;
            _inheritedVelocityChange = Vector2.zero;
        }
    }
}
