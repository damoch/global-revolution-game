using UnityEngine;

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

        private City _capital;
        private void Start()
        {
            _teritoryRenderer = GetComponent<SpriteRenderer>();

            InjectToCities();
        }

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
    }
}