using BananaParty.BehaviorTree;

namespace WC
{
    public class CharacterKickNode : BehaviorNode
    {
        private readonly ICharacterControls _character;
        private readonly bool _kicking;

        public CharacterKickNode(ICharacterControls character, bool kicking)
        {
            _character = character;
            _kicking = kicking;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _character.Kick(_kicking);

            return BehaviorNodeStatus.Success;
        }
    }
}
