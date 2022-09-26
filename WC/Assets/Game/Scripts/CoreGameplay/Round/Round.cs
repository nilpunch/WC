using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class Round : MonoBehaviour
    {
        [SerializeField] private GoalTracker _goalTracker;
        [SerializeField] private Timer _timer;
        [SerializeField] private GoalCounter _goalCounter;
        [SerializeField] private Referee _referee;
        [SerializeField] private GoalAnnouncer _goalAnnouncer;

        private BehaviorNode _behaviorTree;

        public bool IsEnded => _timer.IsEnded && !_goalCounter.IsDraw;

        private void Awake()
        {
            _behaviorTree = new SequenceNode(new IBehaviorNode[]
            {
                new RepeatNode(new SequenceNode(new IBehaviorNode[]
                {
                    // Prepare round
                    new HideGoalAnnouncerNode(_goalAnnouncer),
                    new RefereePreRoundSetupNode(_referee),
                    new WaitNode(1000),

                    // Start round
                    new RefereeThrowBallNode(_referee),
                    new StartTimerNode(_timer),
                    new StartGoalTrackerNode(_goalTracker),

                    // Wait until round end
                    new ParallelFirstCompleteNode(new IBehaviorNode[]
                    {
                        // Wait until goal
                        new RepeatNode(new SequenceNode(new IBehaviorNode[]
                        {
                            new IsTrackerHasGoalNode(_goalTracker),
                        }), BehaviorNodeStatus.Success),

                        // Or wait until timer end, if not draw
                        new RepeatNode(new SequenceNode(new IBehaviorNode[]
                        {
                            new IsTimerEndedNode(_timer),
                            new InverterNode(new IsCountDrawNode(_goalCounter)),
                        }), BehaviorNodeStatus.Success),
                    }, "Round Goal Condition"),

                    // Round ends
                    new StopGoalTrackerNode(_goalTracker),
                    new StopTimerNode(_timer),
                    new RefereeDisallowPlayNode(_referee),

                    // If round has goal, count it and show goal
                    new SelectorNode(new IBehaviorNode[]
                    {
                        new InverterNode(new IsTrackerHasGoalNode(_goalTracker)),
                        new InverterNode(new ShowGoalAnnouncerNode(_goalAnnouncer)),
                        new CountGoalNode(_goalCounter, _goalTracker),
                    }),

                    new WaitNode(1000),

                    // If match not ended, continue loop
                    new SequenceNode(new IBehaviorNode[]
                    {
                        new IsTimerEndedNode(_timer),
                        new InverterNode(new IsCountDrawNode(_goalCounter)),
                    }),
                }, false, "Round loop"), BehaviorNodeStatus.Success),

                new DebugLogNode("Round ended!"),
                new WaitNode(3000),
            });
        }

        private void Update()
        {
            if (!_behaviorTree.Finished)
                _behaviorTree.Execute((long)(Time.time * 1000));

            // TEMPORARY
            if (_behaviorTree.Finished)
                ResetMatch();
        }

        public PlaySide WinedSide()
        {
            if (!IsEnded)
                throw new Exception();

            return _goalCounter.WinSide();
        }

        public void ResetMatch()
        {
            _behaviorTree.Reset();
            _goalTracker.Stop();
            _goalCounter.ResetCount();
            _timer.ResetTime();
        }
    }
}
