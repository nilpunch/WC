using BananaParty.BehaviorTree;

namespace WC
{
    public class StartGoalTrackerNode : BehaviorNode
    {
        private readonly GoalTracker _goalTracker;

        public StartGoalTrackerNode(GoalTracker goalTracker)
        {
            _goalTracker = goalTracker;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _goalTracker.Start();
            return BehaviorNodeStatus.Success;
        }
    }
}
