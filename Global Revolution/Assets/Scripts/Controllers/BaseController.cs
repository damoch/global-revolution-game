using System;
using Assets.Scripts.State;
using Assets.Scripts.World.Base;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BaseController : MonoBehaviour
    {
        [SerializeField]
        private BaseState _baseState;

        private GameController _gameController;

        public BaseState BaseState { get => _baseState; set => _baseState = value; }

        public void UpdateBaseState(DateTime currentDate)
        {
            foreach(var buildingPlace in _baseState.PlacesForBuildings)
            {
                buildingPlace.UpdateBuildingPlace(currentDate);
            }
        }

        public void InjectController(GameController contr)
        {
            _gameController = contr;
        }

        internal void StartBuilding(PlaceForBuilding placeForBuilding, Building building)
        {
            var bldg = Instantiate(building, placeForBuilding.transform.position, placeForBuilding.transform.rotation);
            bldg.gameObject.SetActive(false);
            _baseState.Money -= building.ConstructionCost;
            placeForBuilding.StartConstruction(bldg);
        }
    }
}