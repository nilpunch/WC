using BananaParty.BehaviorTree;

namespace WC
{
    public class CharacterJumpNode : BehaviorNode
    {
        private readonly ICharacterControls _character;

        public CharacterJumpNode(ICharacterControls character)
        {
            _character = character;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _character.Jump(true);

            return BehaviorNodeStatus.Success;
        }
    }
}
