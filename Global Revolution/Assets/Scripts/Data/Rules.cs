using Assets.Scripts.World.Base;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Rules : MonoBehaviour
    {
        [SerializeField]
        private float _capitalCityInfluence;

        [SerializeField]
        private float _normalCityInfluence;

        [SerializeField]
        private Building[] _availableBaseBuildings; 

        public float CapitalCityInfluence { get => _capitalCityInfluence; set => _capitalCityInfluence = value; }
        public float NormalCityInfluence { get => _normalCityInfluence; set => _normalCityInfluence = value; }
        public Building[] AvailableBaseBuildings { get => _availableBaseBuildings; set => _availableBaseBuildings = value; }
    }
}
