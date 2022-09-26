using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class BackToGoalDefenseNode : BehaviorNode
    {
        private readonly FieldDetector _fieldDetector;
        private readonly ICharacterControls _me;

        private readonly float _advanceBoost = 3f;

        public BackToGoalDefenseNode(FieldDetector fieldDetector, ICharacterControls me)
        {
            _fieldDetector = fieldDetector;
            _me = me;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Vector2 advance = _fieldDetector.MyGoalDefensePosition - _me.Position;

            Vector2 advanceInput = Vector2.ClampMagnitude(advance * _advanceBoost, 1f);

            _me.Move(advanceInput);

            return BehaviorNodeStatus.Success;
        }
    }
}
