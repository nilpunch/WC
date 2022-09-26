using System;
using UnityEngine;

namespace WC
{
    public class GoalCounter : MonoBehaviour
    {
        [SerializeField] private GoalCounterView _view;

        private int _leftSideCount;
        private int _rightSideCount;

        public bool IsDraw => _leftSideCount == _rightSideCount;

        public PlaySide LastGoalSide { get; private set; }

        private void Start()
        {
            _view.ShowCount(0, 0);
        }

        public PlaySide WinSide()
        {
            if (IsDraw)
                throw new Exception();

            return _leftSideCount > _rightSideCount ? PlaySide.Left : PlaySide.Right;
        }

        public void CountGoal(PlaySide playSide)
        {
            if (playSide == PlaySide.None)
                return;

            LastGoalSide = playSide;

            switch (playSide)
            {
                case PlaySide.Left:
                    _leftSideCount += 1;
                    break;
                case PlaySide.Right:
                    _rightSideCount += 1;
                    break;
            }

            _view.ShowCount(_leftSideCount, _rightSideCount);
        }

        public void ResetCount()
        {
            _leftSideCount = 0;
            _rightSideCount = 0;
            LastGoalSide = PlaySide.None;
            _view.ShowCount(0, 0);
        }
    }
}
