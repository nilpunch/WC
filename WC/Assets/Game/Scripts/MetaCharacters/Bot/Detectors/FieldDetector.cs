using UnityEngine;

namespace WC
{
    public class FieldDetector : MonoBehaviour
    {
        [SerializeField] private Goal _myGoal;
        [SerializeField] private Goal _opponentGoal;
        [SerializeField] private Transform _goalDefendPosition;

        public Vector2 MyGoalDefensePosition => _goalDefendPosition.position;
        public Vector2 MyGoalPosition => _myGoal.Position;
        public Vector2 OpponentGoalPosition => _opponentGoal.Position;

        public Vector2 FieldCenter => (MyGoalPosition + OpponentGoalPosition) / 2f;

        public float FieldLength => Vector2.Distance(MyGoalPosition, OpponentGoalPosition);
    }
}
