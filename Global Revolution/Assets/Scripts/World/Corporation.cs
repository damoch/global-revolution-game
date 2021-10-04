using Assets.Scripts.Data;
using Assets.Scripts.Data.Factories;
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
        public List<Contract> Contracts;
        public GameClock Clock;

        public IndustryType[] IndustryTypes;
        private int _minuteOfContractGeneration;

        private void Start()
        {
            _minuteOfContractGeneration = UnityEngine.Random.Range(1, 59);
            Clock.OnMinutePassed += TimedEvent;
        }

        private void TimedEvent(DateTime currentTime)
        {
            if(currentTime.Minute != _minuteOfContractGeneration)
            {
                return;
            }
            Contracts.Add(ContractFactory.CreateContractFor(this));
        }
    }
}
