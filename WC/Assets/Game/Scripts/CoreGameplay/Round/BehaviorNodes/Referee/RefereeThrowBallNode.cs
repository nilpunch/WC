using BananaParty.BehaviorTree;

namespace WC
{
    public class RefereeThrowBallNode : BehaviorNode
    {
        private readonly Referee _referee;

        public RefereeThrowBallNode(Referee referee)
        {
            _referee = referee;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _referee.ThrowBall();
            return BehaviorNodeStatus.Success;
        }
    }
}