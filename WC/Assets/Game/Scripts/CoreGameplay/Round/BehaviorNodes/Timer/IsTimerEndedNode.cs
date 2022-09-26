using BananaParty.BehaviorTree;

namespace WC
{
    public class IsTimerEndedNode : BehaviorNode
    {
        private readonly Timer _timer;

        public IsTimerEndedNode(Timer timer)
        {
            _timer = timer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _timer.IsEnded ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
