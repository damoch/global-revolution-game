using Assets.Scripts.Data;
using Assets.Scripts.World;
using Assets.Scripts.World.Base;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class WorldState : MonoBehaviour
    {
        [SerializeField]
        private GameClock _gameClock;

        public GameClock GameClock { get => _gameClock; set => _gameClock = value; }

        public CityBuilding[] CityBuildings;

        public City[] Cities;

        public Country[] Countries;

        public List<Contract> Contracts;

        //singleton
        public static WorldState Instance;

        private void Start()
        {
            Contracts = new List<Contract>();
            Instance = this;
        }
    }
}

