using UnityEngine;

namespace WC
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterInput _characterInput;
        [SerializeField] private Character _character;

        private bool _lastInputJump = false;

        private void Update()
        {
            Vector2 moveDirection = Vector2.zero;
            if (_characterInput.MoveLeft)
            {
                moveDirection += Vector2.left;
            }
            else if (_characterInput.MoveRight)
            {
                moveDirection += Vector2.right;
            }

            _character.Move(moveDirection);

            if (!_character.CanPlay)
            {
                _lastInputJump = !_characterInput.Jump;
            }
            else if (_character.CanPlay && _lastInputJump != _characterInput.Jump)
            {
                _lastInputJump = _characterInput.Jump;
                _character.Jump(_characterInput.Jump);
            }

            _character.Kick(_characterInput.Kick);
        }
    }
}
