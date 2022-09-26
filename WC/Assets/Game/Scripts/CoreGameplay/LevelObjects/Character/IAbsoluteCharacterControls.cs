using UnityEngine;

namespace WC
{
    public interface IAbsoluteCharacterControls
    {
        void Teleport(Vector2 position);
        void AllowPlay(bool allowed);
    }
}
