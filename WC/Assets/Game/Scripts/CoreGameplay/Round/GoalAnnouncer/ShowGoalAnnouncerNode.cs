using BananaParty.BehaviorTree;

namespace WC
{
    public class ShowGoalAnnouncerNode : BehaviorNode
    {
        private readonly GoalAnnouncer _goalAnnouncer;

        public ShowGoalAnnouncerNode(GoalAnnouncer goalAnnouncer)
        {
            _goalAnnouncer = goalAnnouncer;
        }
        
        public override BehaviorNodeStatus OnExecute(long time)
        {
            _goalAnnouncer.Show();
            return BehaviorNodeStatus.Success;
        }
    }
}