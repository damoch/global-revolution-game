using System.Linq;
using Assets.Scripts.World.Base;
using UnityEngine;

namespace Assets.Scripts.State
{
    public class BaseState : MonoBehaviour
    {
        [SerializeField]
        private int _money;

        [SerializeField]
        private PlaceForBuilding[] _placesForBuildings;
        public int Money { get => _money; set => _money = value; }
        public PlaceForBuilding[] PlacesForBuildings { get => _placesForBuildings; set => _placesForBuildings = value; }
        public int EnergyBalance { get => _placesForBuildings.Where(p => !p.ConstructionInProgress && p.Building != null).Sum(pb => pb.Building.EnergyBalance); }
    }

}