using System;
using UnityEngine;

namespace WC
{
    public class CharacterBallKicker : MonoBehaviour
    {
        [SerializeField] private float _altitudeForce = 6f;
        [SerializeField] private float _longitudeForce = 3f;
        [SerializeField] private float _defaultForce = 2f;
        [SerializeField, Range(0f, 1f)] private float _velocityTransferFromCharacter = 0.5f;
        [SerializeField] private float _collisionTimeThreshold = 0.5f;
        [SerializeField] private bool _punchToLeft = false;

        private float _lastCollisionTime = -1f;
        private bool _isKicking;

        private void OnCollisionEnter2D(Collision2D other)
        {
            CollisionHandle(other);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            CollisionHandle(other);
        }

        public void Activate(bool isActive)
        {
            _isKicking = isActive;
        }

        private void CollisionHandle(Collision2D other)
        {
            if (other.rigidbody == null || !other.rigidbody.TryGetComponent<Ball>(out var ball))
                return;

            if (_lastCollisionTime + _collisionTimeThreshold > Time.time)
                return;

            _lastCollisionTime = Time.time;

            Rigidbody2D myRigidbody = other.otherRigidbody;

            if (_isKicking)
            {
                Vector2 punchDirection = _punchToLeft ? Vector2.left : Vector2.right;
                ball.Punch(Vector2.up * _altitudeForce + punchDirection * _longitudeForce +
                           myRigidbody.velocity * _velocityTransferFromCharacter);
            }
            else
            {
                Vector2 punchDirection = (other.rigidbody.position - myRigidbody.position).normalized;
                ball.Punch(punchDirection * _defaultForce + myRigidbody.velocity * _velocityTransferFromCharacter);
            }
        }
    }
}
