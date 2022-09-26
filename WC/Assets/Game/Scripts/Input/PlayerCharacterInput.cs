using UnityEngine;

namespace WC
{
    public class PlayerCharacterInput : MonoBehaviour, ICharacterInput
    {
        [SerializeField] private PointerCharacterInput _pointerCharacterInput;
        [SerializeField] private KeyboardCharacterInput _keyboardCharacterInput;
        [SerializeField] private bool _forcePointerInput;

        private ICharacterInput _characterInput;

        private void Awake()
        {
            if (UnityEngine.Application.isMobilePlatform || _forcePointerInput)
            {
                _characterInput = _pointerCharacterInput;
            }
            else
            {
                _characterInput = _keyboardCharacterInput;
                _pointerCharacterInput.HideVisuals();
            }
        }

        public bool MoveLeft => _characterInput.MoveLeft;
        public bool MoveRight => _characterInput.MoveRight;
        public bool Jump => _characterInput.Jump;
        public bool Kick => _characterInput.Kick;
    }
}
