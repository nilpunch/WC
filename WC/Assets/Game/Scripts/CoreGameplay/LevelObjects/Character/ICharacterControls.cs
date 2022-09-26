using UnityEngine;

namespace WC
{
    public interface ICharacterControls : ICharacterInfo
    {
        void Jump(bool active);
        void Kick(bool active);
        void Move(Vector2 direction);
    }
}
