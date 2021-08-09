using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.World.Base;
using Assets.Scripts.Controllers;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    public class BaseControlPanelController : MonoBehaviour
    {
        [SerializeField]
        private BasePanelState _baseControlState;

        [SerializeField]
        private GameObject _mainPanelObject;

        [SerializeField]
        private GameObject _constructionPanelObject;

        [SerializeField]
        private GameObject _selectPlaceToBuildPanelObject;

        [SerializeField]
        private UnityEngine.UI.Button[] _buildingButton;

        [SerializeField]
        private ConstructionPanelController _constructionPanelController;
        private UiController _uiController;
        private BaseController _baseController;
        private Dictionary<BasePanelState, GameObject> _statesToPanels;
        private Building[] _availableBaseBuildings;
        private Building _currentConstruction;
        
        private void Update()
        {
            if (_currentConstruction == null)
            {
                return;
            }
            if (Input.GetMouseButton((int)MouseButton.LeftMouse))
            {
                CreateBaseBuilding();
            }
        }

        private void CreateBaseBuilding()
        {
            var clicked = GetClickedObject();
            if (clicked == null)
            {
                return;
            }

            var place = clicked.GetComponent<PlaceForBuilding>();
            if (place == null || 
            !_baseController.CanStartConstructionOnSelectedPlace(place, _currentConstruction))
            {
                return;
            }
            ActivatePanel(BasePanelState.Building);
            _baseController.StartBuilding(place, _currentConstruction);
            _constructionPanelController.CheckWhatCanBeBuilt();
            _uiController.UpdateBaseData();
            _currentConstruction = null;
        }

        public void ActivatePanel(string stateName)
        {
            var state = (BasePanelState)Enum.Parse(typeof(BasePanelState), stateName);
            ActivatePanel(state);
        }

        public void ActivatePanel(BasePanelState state){
            _statesToPanels[_baseControlState].SetActive(false);
            _baseControlState = state;
            _statesToPanels[_baseControlState].SetActive(true);
        }

        internal void InjectAvailableBuildings(Building[] availableBaseBuildings, BaseController baseController, UiController uiController)
        {
            _uiController = uiController;
            _baseController = baseController;
            _statesToPanels = new Dictionary<BasePanelState, GameObject>(){
                {BasePanelState.Building, _constructionPanelObject},
                {BasePanelState.Main, _mainPanelObject},
                {BasePanelState.SelectPlaceForBuilding, _selectPlaceToBuildPanelObject}
            };

            _availableBaseBuildings = availableBaseBuildings;
            var buttonsToBuildings = new Dictionary<UnityEngine.UI.Button, Building>();
            var i = 0;
            foreach(var button in _buildingButton)
            {
                var building = _availableBaseBuildings[i++];
                button.onClick.AddListener(() =>{
                    StartConstruction(building);
                });
                buttonsToBuildings.Add(button, building);
            }
            _constructionPanelController.ButtonToBuilding = buttonsToBuildings;
            _constructionPanelController.BaseState = baseController.BaseState;
        }

        private void StartConstruction(Building building)
        {
            if(!_baseController.CanStartConstruction(building)){
                return;
            }
            ActivatePanel(BasePanelState.SelectPlaceForBuilding);
            _currentConstruction = building;
        }

        public void CancelConstruction(){
            _currentConstruction = null;
            ActivatePanel(BasePanelState.Building);
        }

        private GameObject GetClickedObject()
        {
            var screenToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(new Vector2(screenToWorld.x, screenToWorld.y), Vector2.zero, 0f);

            return hit.transform?.gameObject;            
        }

        private void OnDisable()
        {
            _currentConstruction = null;
        }
    }
}