using BananaParty.BehaviorTree;

namespace WC
{
    public class IsTrackerHasGoalNode : BehaviorNode
    {
        private readonly GoalTracker _goalTracker;

        public IsTrackerHasGoalNode(GoalTracker goalTracker)
        {
            _goalTracker = goalTracker;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _goalTracker.HasGoal ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
