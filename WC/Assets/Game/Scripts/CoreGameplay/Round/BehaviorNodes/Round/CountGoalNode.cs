using BananaParty.BehaviorTree;

namespace WC
{
    public class CountGoalNode : BehaviorNode
    {
        private readonly GoalCounter _goalCounter;
        private readonly GoalTracker _goalTracker;

        public CountGoalNode(GoalCounter goalCounter, GoalTracker goalTracker)
        {
            _goalCounter = goalCounter;
            _goalTracker = goalTracker;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _goalCounter.CountGoal(_goalTracker.GoalSide());
            return BehaviorNodeStatus.Success;
        }
    }
}
