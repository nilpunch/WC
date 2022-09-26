using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class IsBallOnMyHalfFieldNode : BehaviorNode
    {
        private readonly BallDetector _ballDetector;
        private readonly FieldDetector _fieldDetector;

        public IsBallOnMyHalfFieldNode(BallDetector ballDetector, FieldDetector fieldDetector)
        {
            _ballDetector = ballDetector;
            _fieldDetector = fieldDetector;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            bool isBallOnMySide = Vector2.Distance(_ballDetector.BallPosition, _fieldDetector.MyGoalPosition) <
                                  _fieldDetector.FieldLength / 2f;

            return isBallOnMySide ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
