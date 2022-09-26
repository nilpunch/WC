using BananaParty.BehaviorTree;

namespace WC
{
    public class CharacterFallNode : BehaviorNode
    {
        private readonly ICharacterControls _character;

        public CharacterFallNode(ICharacterControls character)
        {
            _character = character;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _character.Jump(false);

            return BehaviorNodeStatus.Success;
        }
    }
}
