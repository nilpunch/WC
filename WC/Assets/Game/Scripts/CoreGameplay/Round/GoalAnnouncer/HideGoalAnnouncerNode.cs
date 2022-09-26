using BananaParty.BehaviorTree;

namespace WC
{
    public class HideGoalAnnouncerNode : BehaviorNode
    {
        private readonly GoalAnnouncer _goalAnnouncer;

        public HideGoalAnnouncerNode(GoalAnnouncer goalAnnouncer)
        {
            _goalAnnouncer = goalAnnouncer;
        }
        
        public override BehaviorNodeStatus OnExecute(long time)
        {
            _goalAnnouncer.Hide();
            return BehaviorNodeStatus.Success;
        }
    }
}