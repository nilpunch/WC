using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class IsBallCloseToMeNode : BehaviorNode
    {
        private readonly BallDetector _ballDetector;
        private readonly ICharacterInfo _me;
        private readonly float _distance;

        public IsBallCloseToMeNode(BallDetector ballDetector, ICharacterInfo me, float distance)
        {
            _ballDetector = ballDetector;
            _me = me;
            _distance = distance;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            bool isBallCloseToMe = Mathf.Abs(_me.Position.x - _ballDetector.BallPosition.x) < _distance;

            return isBallCloseToMe ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
