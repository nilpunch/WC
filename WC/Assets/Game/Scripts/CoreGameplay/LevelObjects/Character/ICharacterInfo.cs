using UnityEngine;

namespace WC
{
    public interface ICharacterInfo
    {
        bool IsOnGround { get; }
        bool CanPlay { get; }

        Vector2 Position { get; }
        Vector2 Velocity { get; }
    }
}
