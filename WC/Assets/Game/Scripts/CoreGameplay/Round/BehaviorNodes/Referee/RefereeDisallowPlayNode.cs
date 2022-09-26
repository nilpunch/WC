using BananaParty.BehaviorTree;

namespace WC
{
    public class RefereeDisallowPlayNode : BehaviorNode
    {
        private readonly Referee _referee;

        public RefereeDisallowPlayNode(Referee referee)
        {
            _referee = referee;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _referee.DisallowCharactersPlay();
            return BehaviorNodeStatus.Success;
        }
    }
}
