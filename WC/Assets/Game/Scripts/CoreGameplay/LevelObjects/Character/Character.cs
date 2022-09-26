using System;
using UnityEngine;

namespace WC
{
    public class Character : MonoBehaviour, IAbsoluteCharacterControls, ICharacterControls
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private CharacterBallKicker _characterBallKicker;
        [SerializeField] private CharacterHorizontalMovement _characterHorizontalMovement;
        [SerializeField] private CharacterVerticalMovement _characterVerticalMovement;
        [SerializeField] private CharacterPhysicsPipeline _characterPhysicsPipeline;

        public Vector2 Position => transform.position;
        public Vector2 Velocity => _rigidbody2D.velocity;

        public bool IsOnGround => _characterVerticalMovement.IsOnGround;

        public bool CanPlay { get; private set; }

        private void FixedUpdate()
        {
            _characterPhysicsPipeline.ManualUpdate();
        }

        public void Jump(bool active)
        {
            if (!CanPlay)
                return;

            if (active)
            {
                _characterVerticalMovement.Jump();
            }
            else
            {
                _characterVerticalMovement.Fall();
            }
        }

        public void Kick(bool active)
        {
            if (!CanPlay)
                return;

            _characterBallKicker.Activate(active);
        }

        public void Move(Vector2 direction)
        {
            if (!CanPlay)
                return;

            _characterHorizontalMovement.Move(direction);
        }

        public void Teleport(Vector2 position)
        {
            transform.position = position;
        }

        public void AllowPlay(bool allowed)
        {
            CanPlay = allowed;

            // Resets default move input
            if (!CanPlay)
            {
                _characterHorizontalMovement.Move(Vector3.zero);
                _characterVerticalMovement.Fall();
                _characterBallKicker.Activate(false);
            }
        }
    }
}
