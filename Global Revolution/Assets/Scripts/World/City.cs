using UnityEngine;

namespace Assets.Scripts.World
{
    public class City : MonoBehaviour
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private bool _isCapitalCity;

        private Country _country;

        public bool IsCapitalCity { get => _isCapitalCity; }

        public void InjectCountry(Country country)
        {
            _country = country;
        }
    }
}
