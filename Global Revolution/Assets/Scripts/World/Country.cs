using UnityEngine;
using Assets.Scripts.Controllers;

namespace Assets.Scripts.World
{
    public class Country : MonoBehaviour
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private SpriteRenderer _teritoryRenderer;

        [SerializeField]
        private City[] _cities;

        private GameController _gameController;

        public float EconomicAxis
        {
            get
            {
                var result = 0f;
                var weightsSum = 0f;

                foreach (var city in _cities)
                {
                    result += city.IsCapitalCity ? city.CityGovernment.EconomicAxis * _gameController.Rules.CapitalCityInfluence : 
                    city.CityGovernment.EconomicAxis * _gameController.Rules.NormalCityInfluence;
                    
                    weightsSum += city.IsCapitalCity ? _gameController.Rules.CapitalCityInfluence : _gameController.Rules.NormalCityInfluence;
                }

                return result / weightsSum;
            }
        }

        public float GovernanceAxis
        {
            get
            {
                var result = 0f;
                var weightsSum = 0f;

                foreach (var city in _cities)
                {
                    result += city.IsCapitalCity ? city.CityGovernment.GovernanceAxis * _gameController.Rules.CapitalCityInfluence :
                    city.CityGovernment.GovernanceAxis * _gameController.Rules.NormalCityInfluence;

                    weightsSum += city.IsCapitalCity ? _gameController.Rules.CapitalCityInfluence : _gameController.Rules.NormalCityInfluence;
                }

                return result / weightsSum;
            }
        }

        private City _capital;

        private void InjectToCities()
        {            
            foreach (var city in _cities)
            {
                if(city.IsCapitalCity)
                {
                    _capital = city;
                }
                city.InjectCountry(this);
            }
        }

        public void InjectGameCotroller(GameController gameController)
        {
            _gameController = gameController;            
            _teritoryRenderer = GetComponent<SpriteRenderer>();

            InjectToCities();
        }
    }
}