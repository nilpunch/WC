using BananaParty.BehaviorTree;

namespace WC
{
    public class StopTimerNode : BehaviorNode
    {
        private readonly Timer _timer;

        public StopTimerNode(Timer timer)
        {
            _timer = timer;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _timer.Stop();
            return BehaviorNodeStatus.Success;
        }
    }
}
