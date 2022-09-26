using BananaParty.BehaviorTree;

namespace WC
{
    public class RefereePreRoundSetupNode : BehaviorNode
    {
        private readonly Referee _referee;

        public RefereePreRoundSetupNode(Referee referee)
        {
            _referee = referee;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _referee.PreRoundSetup();
            return BehaviorNodeStatus.Success;
        }
    }
}