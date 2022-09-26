using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class IsBallComingToMyGoalNode : BehaviorNode
    {
        private readonly BallDetector _ballDetector;
        private readonly FieldDetector _fieldDetector;

        private readonly float _comingThreshold = -0.5f;

        public IsBallComingToMyGoalNode(BallDetector ballDetector, FieldDetector fieldDetector)
        {
            _ballDetector = ballDetector;
            _fieldDetector = fieldDetector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Vector2 directionToBallFromGoal = (_ballDetector.BallPosition - _fieldDetector.MyGoalPosition).normalized;
            float comingFactor = Vector2.Dot(directionToBallFromGoal, _ballDetector.BallVelocity);

            bool isBallComingToMyGoal = comingFactor < _comingThreshold;

            return isBallComingToMyGoal ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
