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

        private void MinutePassed(DateTime currentTime)
        {
            if (currentTime.Minute != _minuteOfContractGeneration)
            {
                return;
            }
            CheckContractGenerator();
        }

        private void CheckContractGenerator()
        {
            if (Contracts.Count >= _gameController.Rules.MaxActiveContracts)
            {
                return;
            }
            var contract = ContractFactory.CreateContractFor(this);
            if (contract == null)
            {
                return;
            }
            Contracts.Add(contract);
            _gameController.LogGameEvent($"{Name} announced a contract to {contract.ContractType} {contract.Target.TargetName} in {contract.Target.City.Name} that belongs to {contract.Target.TargetOwner.Name}. Reward: {contract.Reward} deadline: {contract.Deadline}");
        }

        internal void InjectGameController(GameController gameController, GameClock gameClock)
        {
            _gameController = gameController;
            gameClock.OnMinutePassed += MinutePassed;
        }
    }
}
