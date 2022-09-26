using BananaParty.BehaviorTree;

namespace WC
{
    public class StopGoalTrackerNode : BehaviorNode
    {
        private readonly GoalTracker _goalTracker;

        public StopGoalTrackerNode(GoalTracker goalTracker)
        {
            _goalTracker = goalTracker;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _goalTracker.Stop();
            return BehaviorNodeStatus.Success;
        }
    }
}
