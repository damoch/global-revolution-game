using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Rules : MonoBehaviour
    {
        [SerializeField]
        private float _capitalCityInfluence;

        [SerializeField]
        private float _normalCityInfluence;

        public float CapitalCityInfluence { get => _capitalCityInfluence; set => _capitalCityInfluence = value; }
        public float NormalCityInfluence { get => _normalCityInfluence; set => _normalCityInfluence = value; }
    }
}
