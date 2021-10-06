using Assets.Scripts.Controllers;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Factories;
using Assets.Scripts.World.Base;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class Corporation : MonoBehaviour
    {
        public string Name;

        public List<Corporation> HostileCorporations;
        public List<Corporation> AlliedCorporations;
        public List<CityBuilding> ContractTargets;
        public List<Contract> Contracts;
        public GameClock Clock;

        public IndustryType[] IndustryTypes;
        private int _minuteOfContractGeneration;
        private GameController _gameController;

        private void Start()
        {
            _minuteOfContractGeneration = UnityEngine.Random.Range(1, 59);
            Contracts = new List<Contract>();
        }

        private void TimedEvent(DateTime currentTime)
        {
            if(currentTime.Minute != _minuteOfContractGeneration)
            {
                return;
            }
            var contract = ContractFactory.CreateContractFor(this);
            if(contract == null)
            {
                return;
            }
            Contracts.Add(contract);
            _gameController.LogGameEvent($"{Name} announced a contract to {contract.ContractType} {contract.Target.TargetName} that belongs to {contract.Target.TargetOwner.Name}");
        }

        internal void InjectGameController(GameController gameController, GameClock gameClock)
        {
            _gameController = gameController;
            gameClock.OnMinutePassed += TimedEvent;
        }
    }
}
