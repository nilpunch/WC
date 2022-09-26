using BananaParty.BehaviorTree;

namespace WC
{
    public class StartTimerNode : BehaviorNode
    {
        private readonly Timer _timer;

        public StartTimerNode(Timer timer)
        {
            _timer = timer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _timer.Start();
            return BehaviorNodeStatus.Success;
        }
    }
}
