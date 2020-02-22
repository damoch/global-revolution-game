using Assets.Scripts.World;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class WorldState : MonoBehaviour
    {
        [SerializeField]
        private GameClock _gameClock;

        public GameClock GameClock { get => _gameClock; set => _gameClock = value; }

        private void Start()
        {

        }
    }
}

