using Assets.Scripts.World.Base;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Rules : MonoBehaviour
    {
        [SerializeField]
        private Building[] _availableBaseBuildings; 
        public Building[] AvailableBaseBuildings { get => _availableBaseBuildings; set => _availableBaseBuildings = value; }
        public int MaxActiveContracts { get => _maxActiveContracts; set => _maxActiveContracts = value; }

        [SerializeField]
        private int _maxActiveContracts;
    }
}
