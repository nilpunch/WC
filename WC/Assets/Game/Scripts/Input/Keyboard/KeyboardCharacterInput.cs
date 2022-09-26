using UnityEngine;

namespace WC
{
    public class KeyboardCharacterInput : MonoBehaviour, ICharacterInput
    {
        [SerializeField] private KeyCode _moveLeftKey = KeyCode.A;
        [SerializeField] private KeyCode _moveRightKey = KeyCode.D;
        [SerializeField] private KeyCode _jumpKey = KeyCode.W;
        [SerializeField] private KeyCode _kickKey = KeyCode.Space;

        public bool MoveLeft => Input.GetKey(_moveLeftKey);
        public bool MoveRight => Input.GetKey(_moveRightKey);
        public bool Jump => Input.GetKey(_jumpKey);
        public bool Kick => Input.GetKey(_kickKey);
    }
}
