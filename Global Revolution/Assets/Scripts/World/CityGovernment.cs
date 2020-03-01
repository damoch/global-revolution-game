using UnityEngine;

namespace Assets.Scripts.World
{
    public class CityGovernment : MonoBehaviour
    {
        [SerializeField, Range(-10,10)]
        private float _economicAxis;
        [SerializeField, Range(-10,10)]
        private float _governanceAxis;

        public float EconomicAxis { get => _economicAxis; set => _economicAxis = value; }
        public float GovernanceAxis { get => _governanceAxis; set => _governanceAxis = value; }
    }
}