using BananaParty.BehaviorTree;

namespace WC
{
    public class IsBallUnderMeNode : BehaviorNode
    {
        private readonly BallDetector _ballDetector;
        private readonly ICharacterInfo _me;

        private readonly float _threshold = -0.25f;

        public IsBallUnderMeNode(BallDetector ballDetector, ICharacterInfo me)
        {
            _ballDetector = ballDetector;
            _me = me;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            bool isBallOverMyHead = _ballDetector.BallPosition.y - _me.Position.y < _threshold;

            return isBallOverMyHead ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
