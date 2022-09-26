using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class AdvanceToBallNode : BehaviorNode
    {
        private readonly BallDetector _ballDetector;
        private readonly ICharacterControls _me;

        private readonly float _advanceBoost = 10f;

        public AdvanceToBallNode(BallDetector ballDetector, ICharacterControls me)
        {
            _ballDetector = ballDetector;
            _me = me;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Vector2 advance = _ballDetector.BallPosition - _me.Position;

            Vector2 advanceInput = Vector2.ClampMagnitude(advance * _advanceBoost, 1f);

            _me.Move(advanceInput);

            return BehaviorNodeStatus.Success;
        }
    }
}
