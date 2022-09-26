using BananaParty.BehaviorTree;
using UnityEngine;

namespace WC
{
    public class DebugLogNode : BehaviorNode
    {
        private readonly string _message;

        public DebugLogNode(string message)
        {
            _message = message;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            Debug.Log(_message);
            return BehaviorNodeStatus.Success;
        }
    }
}
