using BananaParty.BehaviorTree;

namespace WC
{
    public class IsCountDrawNode : BehaviorNode
    {
        private readonly GoalCounter _goalCounter;

        public IsCountDrawNode(GoalCounter goalCounter)
        {
            _goalCounter = goalCounter;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _goalCounter.IsDraw ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
