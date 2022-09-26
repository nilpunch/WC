using UnityEngine;

namespace WC
{
    public class PointerCharacterInput : MonoBehaviour, ICharacterInput
    {
        [SerializeField] private PointerInput _moveLeftButton;
        [SerializeField] private PointerInput _moveRightButton;
        [SerializeField] private PointerInput _jumpButton;
        [SerializeField] private PointerInput _kickButton;

        public bool MoveLeft => _moveLeftButton.IsPressed;
        public bool MoveRight => _moveRightButton.IsPressed;
        public bool Jump => _jumpButton.IsPressed;
        public bool Kick => _kickButton.IsPressed;

        public void HideVisuals()
        {
            gameObject.SetActive(false);
        }
    }
}
