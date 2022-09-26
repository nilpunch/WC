using BananaParty.BehaviorTree;

namespace WC
{
    public class CanCharacterPlayNode : BehaviorNode
    {
        private readonly ICharacterInfo _character;

        public CanCharacterPlayNode(ICharacterInfo character)
        {
            _character = character;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            return _character.CanPlay ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}
