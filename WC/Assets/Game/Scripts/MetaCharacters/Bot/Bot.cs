using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private Character _character;

        [Header("Detectors")]
        [SerializeField] private BallDetector _ballDetector;
        [SerializeField] private FieldDetector _fieldDetector;
        [SerializeField] private OpponentDetector _opponentDetector;

        private BehaviorNode _behaviorTree;

        private void Awake()
        {
            _behaviorTree = new RepeatNode(new SelectorNode(new IBehaviorNode[]
            {
                new SequenceNode(new IBehaviorNode[]
                {
                    new IsBallOnMyHalfFieldNode(_ballDetector, _fieldDetector),

                    new CharacterKickNode(_character, true),

                    new ParallelSequenceNode(new IBehaviorNode[]
                    {
                        new RepeatNode(new SelectorNode(new IBehaviorNode[]
                        {
                            new SequenceNode(new IBehaviorNode[]
                            {
                                new IsBallUnderMeNode(_ballDetector, _character),
                                new BackToGoalDefenseNode(_fieldDetector, _character),
                            }),

                            new AdvanceToBallNode(_ballDetector, _character),
                        })),

                        new RepeatNode(new SelectorNode(new IBehaviorNode[]
                        {
                            new SequenceNode(new IBehaviorNode[]
                            {
                                new IsBallComingToMyGoalNode(_ballDetector, _fieldDetector),
                                new IsBallOverMyHeadNode(_ballDetector, _character),
                                new IsBallCloseToMeNode(_ballDetector, _character, 2f),
                                new CharacterJumpNode(_character),
                            }),

                            new SequenceNode(new IBehaviorNode[]
                            {
                                new IsBallComingToMyGoalNode(_ballDetector, _fieldDetector),
                                new IsBallCloseToMeNode(_ballDetector, _character, 2f),
                                new ConstantNode(BehaviorNodeStatus.Success)
                            }),

                            new CharacterFallNode(_character),
                        })),
                    })
                }, true),

                new BackToGoalDefenseNode(_fieldDetector, _character),

            }, true));
        }

        private void Update()
        {
            if (_behaviorTree.Finished)
                _behaviorTree.Reset();

            _behaviorTree.Execute((long)(Time.time * 1000));
        }
    }
}
