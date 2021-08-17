using UnityEngine;
using Assets.Scripts.Controllers;

namespace Assets.Scripts.World
{
    public class Country : MonoBehaviour
    {
        [SerializeField]
        private string _name;


        [SerializeField]
        private City[] _cities;

        private GameController _gameController;

        private void InjectToCities()
        {            
            foreach (var city in _cities)
            {
                city.InjectCountry(this);
            }
        }

        public void InjectGameCotroller(GameController gameController)
        {
            _gameController = gameController;
            InjectToCities();
        }
    }
}