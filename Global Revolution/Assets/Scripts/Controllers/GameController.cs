﻿using Assets.Scripts.State;
using Assets.Scripts.World;
using Assets.Scripts.UI;
using System.Text;
using UnityEngine;
using Assets.Scripts.Data;
using System.Collections.Generic;
using Assets.Scripts.Data.Factories;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private WorldState _worldState;

        [SerializeField]
        private UiController _uiController;

        [SerializeField]
        private Country[] _countries;

        [SerializeField]
        private BaseController _baseController;

        public Corporation[] Corporations;
        public ContractFactory ContractFactory;
        private Rules _rules;
        private Scenario _scenario;
        private GamePlayState _gamePlayState;
        public Rules Rules { get => _rules; set => _rules = value; }
        public BaseController BaseController { get => _baseController; set => _baseController = value; }

        private void Start()
        {
            Debug.Log(GetAboutString());
            _rules = GetComponent<Rules>();
            _scenario = GetComponent<Scenario>();

            SetUpScenario();
            _worldState.GameClock.OnMinutePassed += _uiController.UpdateClockValue;
            _worldState.GameClock.OnMinutePassed += _baseController.UpdateBaseState;

            InjectToOthers();
            _gamePlayState = GamePlayState.WorldMap;
            _uiController.ChangeView(_gamePlayState);
            _uiController.UpdateBaseData();
        }

        private void SetUpScenario()
        {
            _worldState.GameClock.SetStartupDate(_scenario.ScenarioStartDate);
            _baseController.BaseState.Money = _scenario.StartingMoney;
        }

        private void InjectToOthers()
        {
            _baseController.InjectController(this);
            _uiController.InjectController(this);
            ContractFactory.SetRulesAndState(_rules, _worldState);


            foreach (var country in _countries)
            {
                country.InjectGameCotroller(this);
            }

            foreach (var corporation in Corporations)
            {
                corporation.InjectGameController(this, _worldState.GameClock);
            }
        }

        public string GetAboutString()
        {
            var sb = new StringBuilder();
            sb.Append(Application.productName);
            sb.Append(" by ");
            sb.Append(Application.companyName);
            sb.Append("\nVersion: ");
            sb.Append(Application.version);
            sb.Append("\nBUILD NO:");
            sb.Append(Application.buildGUID);

            return sb.ToString();
        }

        public void LogGameEvent(string message)
        {
            _uiController.WorldPanelController.GameLogController.LogMessage($"[{_worldState.GameClock.ClockValue}] {message}");
        }

        public void ChangeGamePlayState()
        {
            if(_gamePlayState == GamePlayState.WorldMap)
            {
                _gamePlayState = GamePlayState.BaseView;
                _worldState.GameClock.SetClockRunning(false);
            }
            else if(_gamePlayState == GamePlayState.BaseView)
            {
                _gamePlayState = GamePlayState.WorldMap;
                _worldState.GameClock.SetClockRunning(true);
            }
            _uiController.ChangeView(_gamePlayState);
        }
    }
}
