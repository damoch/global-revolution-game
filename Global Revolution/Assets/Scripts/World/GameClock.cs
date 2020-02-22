using Assets.Scripts.World.Delegates;
using System;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class GameClock : MonoBehaviour
    {
        [SerializeField]
        private string _gameStartDate;

        [SerializeField]
        private float _minuteLengthInSeconds;

        [SerializeField]
        private bool _isClockOn;

        private float _elapsedSeconds;

        public DateTime ClockValue { get; set; }

        public OnMinutePassed OnMinutePassed { get; set; }
        private void Start()
        {
            ClockValue = DateTime.Parse(_gameStartDate);
            _elapsedSeconds = 0;
        }

        private void FixedUpdate()
        {
            if (!_isClockOn)
            {
                return;
            }
            _elapsedSeconds += Time.deltaTime;

            if (_elapsedSeconds >= _minuteLengthInSeconds)
            {
                PassMinuteOfTime();
                _elapsedSeconds = 0;
            }
        }

        private void PassMinuteOfTime()
        {
            ClockValue = ClockValue.AddMinutes(1);
            OnMinutePassed?.Invoke(ClockValue);
        }
    }
}
