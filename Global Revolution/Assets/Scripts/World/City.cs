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
        private CityGovernment _cityGovernment;

        public bool IsCapitalCity { get => _isCapitalCity; }
        public CityGovernment CityGovernment { get => _cityGovernment; set => _cityGovernment = value; }

        public void InjectCountry(Country country)
        {
            _cityGovernment = GetComponent<CityGovernment>();
            _country = country;
        }
    }
}
