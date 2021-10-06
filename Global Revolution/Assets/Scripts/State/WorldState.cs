using Assets.Scripts.World;
using Assets.Scripts.World.Base;
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

        private void Start()
        {

        }
    }
}

