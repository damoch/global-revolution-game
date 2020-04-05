using System;
using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class PlaceForBuilding : MonoBehaviour
    {
        [SerializeField]
        private Building _building;

        private bool _constructionInProgress;

        public bool ConstructionInProgress { get => _constructionInProgress; }
        public Building Building { get => _building; }

        private int _elapsedMinutes;

        private void Start()
        {
            if(_building != null){
                _building.gameObject.transform.position = transform.position;
            }
        }

        public void StartConstruction(Building building)
        {
            if(_constructionInProgress || _building != null){
                return;
            }
            _constructionInProgress = true;
            _elapsedMinutes = 0;
            _building = building;
            _building.gameObject.SetActive(false);
        }

        public void UpdateBuildingPlace(DateTime currentDate)
        {
            if(_constructionInProgress)
            {
                _elapsedMinutes++;
                if(_elapsedMinutes == _building.BuildTimeInMinutes)
                {
                    _constructionInProgress = false;
                    _building.gameObject.SetActive(true);
                }
            }
        }
    }
}