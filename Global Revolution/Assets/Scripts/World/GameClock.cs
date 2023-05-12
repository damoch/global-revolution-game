using Assets.Scripts.World.Delegates;
using System;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class GameClock : MonoBehaviour
    {
        [SerializeField]
        private float _minuteLengthInSeconds;

        [SerializeField]
        private bool _isClockOn;

        private float _elapsedSeconds;

        public DateTime ClockValue { get; set; }

        public OnMinutePassed OnMinutePassed { get; set; }
        public OnHourPassed OnHourPassed { get; private set; }

        private void Start()
        {
            _elapsedSeconds = 0;
        }

        public void SetStartupDate(string startupDate)
        {
            ClockValue = DateTime.Parse(startupDate);
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

            if(ClockValue.Minute == 0)
            {
                OnHourPassed?.Invoke(ClockValue);
            }
        }

        public void SetClockRunning(bool isRunning)
        {
            _isClockOn = isRunning;
        }
    }
}
