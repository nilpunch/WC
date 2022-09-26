using System;
using UnityEngine;

namespace WC
{
    public class Referee : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private GoalCounter _goalCounter;
        [SerializeField] private Character _leftCharacter;
        [SerializeField] private Character _rightCharacter;
        [SerializeField] private Ball _ball;

        [Header("Default positions")]
        [SerializeField] private Transform _ballSpawnPoint;
        [SerializeField] private Transform _characterLeftSpawnPoint;
        [SerializeField] private Transform _characterRightSpawnPoint;

        [Header("Ball throw settings")]
        [SerializeField] private float _ballThrowAltitude = 2f;
        [SerializeField] private float _ballThrowLongitude = 5f;

        public void PreRoundSetup()
        {
            _leftCharacter.Teleport(_characterLeftSpawnPoint.position);
            _rightCharacter.Teleport(_characterRightSpawnPoint.position);

            _ball.Teleport(_ballSpawnPoint.position);
            _ball.Hide();
        }

        public void ThrowBall()
        {
            _leftCharacter.AllowPlay(true);
            _rightCharacter.AllowPlay(true);

            _ball.Show();

            switch (_goalCounter.LastGoalSide)
            {
                case PlaySide.None:
                    _ball.Punch(Vector2.up * _ballThrowAltitude);
                    break;
                case PlaySide.Left:
                    _ball.Punch(new Vector2(_ballThrowLongitude, _ballThrowAltitude));
                    break;
                case PlaySide.Right:
                    _ball.Punch(new Vector2(-_ballThrowLongitude, _ballThrowAltitude));
                    break;
            }
        }

        public void DisallowCharactersPlay()
        {
            _leftCharacter.AllowPlay(false);
            _rightCharacter.AllowPlay(false);
        }
    }
}
