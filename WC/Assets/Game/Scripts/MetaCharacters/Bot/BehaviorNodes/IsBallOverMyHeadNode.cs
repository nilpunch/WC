using BananaParty.BehaviorTree;

namespace WC
{
    public class IsBallOverMyHeadNode : BehaviorNode
    {
        private readonly BallDetector _ballDetector;
        private readonly ICharacterInfo _me;

        private readonly float _threshold = 1f;

        public IsBallOverMyHeadNode(BallDetector ballDetector, ICharacterInfo me)
        {
            _ballDetector = ballDetector;
            _me = me;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            bool isBallOverMyHead = _ballDetector.BallPosition.y - _threshold > _me.Position.y;

            return isBallOverMyHead ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
