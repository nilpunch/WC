using BananaParty.BehaviorTree;

namespace WC
{
    public class IsCharacterOnGroundNode : BehaviorNode
    {
        private readonly ICharacterInfo _character;

        public IsCharacterOnGroundNode(ICharacterInfo character)
        {
            _character = character;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _character.IsOnGround ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
