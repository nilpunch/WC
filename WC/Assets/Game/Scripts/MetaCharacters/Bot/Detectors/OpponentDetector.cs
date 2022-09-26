using UnityEngine;

namespace WC
{
    public class OpponentDetector : MonoBehaviour
    {
        [SerializeField] private Character _opponent;

        public Vector2 OpponentPosition => _opponent.Position;
        public Vector2 OpponentVelocity => _opponent.Velocity;
    }
}