using System;
using UnityEngine;

namespace WC
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;

        [Space, SerializeField] private float _matchTime = 60f;

        private float _elapsedTime;
        private bool _active;

        public bool IsEnded => _elapsedTime > _matchTime;

        private void Update()
        {
            if (_active)
                _elapsedTime += Time.deltaTime;

            _timerView.ShowTimeLeft(_matchTime - _elapsedTime);
        }

        public void Start()
        {
            _active = true;
        }

        public void Stop()
        {
            _active = false;
        }

        public void ResetTime()
        {
            _elapsedTime = 0f;
        }
    }
}
