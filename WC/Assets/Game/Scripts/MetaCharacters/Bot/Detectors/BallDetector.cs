using UnityEngine;

namespace WC
{
    public class BallDetector : MonoBehaviour
    {
        [SerializeField] private Ball _ball;

        public Vector2 BallPosition => _ball.Position;
        public Vector2 BallVelocity => _ball.Velocity;
    }
}