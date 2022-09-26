using System;
using UnityEngine;

namespace WC
{
    public class Goal : MonoBehaviour, IGoal, IGoalInfo
    {
        [SerializeField] private GoalTrigger _goalTrigger;

        public Vector2 Position => transform.position;

        public bool HasGoal => _goalTrigger.Triggered;

        public void ResetGoal()
        {
            _goalTrigger.ResetTrigger();
        }
    }
}
