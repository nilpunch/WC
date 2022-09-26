using System;
using UnityEngine;

namespace WC
{
    public class GoalTracker : MonoBehaviour
    {
        [SerializeField] private Goal _leftGoal;
        [SerializeField] private Goal _rightGoal;

        private PlaySide _winedSide;
        private bool _isRoundEnded;

        public bool HasGoal => _isRoundEnded && _winedSide != PlaySide.None;

        private void Update()
        {
            if (_isRoundEnded)
                return;

            if (_leftGoal.HasGoal)
            {
                _isRoundEnded = true;
                _winedSide = PlaySide.Right;
            }
            else if (_rightGoal.HasGoal)
            {
                _isRoundEnded = true;
                _winedSide = PlaySide.Left;
            }
        }

        public PlaySide GoalSide()
        {
            if (!HasGoal)
                throw new Exception();

            return _winedSide;
        }

        public void Start()
        {
            _isRoundEnded = false;
            _winedSide = PlaySide.None;

            _leftGoal.ResetGoal();
            _rightGoal.ResetGoal();
        }

        public void Stop()
        {
            _isRoundEnded = true;
        }
    }
}
