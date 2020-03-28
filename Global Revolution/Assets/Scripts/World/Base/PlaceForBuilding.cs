using System;
using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class PlaceForBuilding : MonoBehaviour
    {
        [SerializeField]
        private Building _building;

        private bool _isBuilding;

        public bool IsBuilding { get => _isBuilding; }

        private int _elapsedMinutes;

        private void Start()
        {
            if(_building != null){
                _building.gameObject.transform.position = transform.position;
            }
        }

        public void StartConstruction(Building building)
        {
            if(_isBuilding || _building != null){
                return;
            }
            _isBuilding = true;
            _elapsedMinutes = 0;
            _building = building;
            _building.gameObject.SetActive(false);
        }

        public void UpdateBuildingPlace(DateTime currentDate)
        {
            if(_isBuilding)
            {
                _elapsedMinutes++;
                if(_elapsedMinutes == _building.BuildTimeInMinutes)
                {
                    _isBuilding = false;
                    _building.gameObject.SetActive(true);
                }
            }
        }
    }
}