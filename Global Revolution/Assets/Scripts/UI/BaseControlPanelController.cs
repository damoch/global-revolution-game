using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.State;
using Assets.Scripts.Controllers;
using System.Collections.Generic;

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

        private Dictionary<BasePanelState, GameObject> _statesToPanels;


        private void Start()
        {
            _statesToPanels = new Dictionary<BasePanelState, GameObject>(){
                {BasePanelState.Building, _constructionPanelObject},
                {BasePanelState.Main, _mainPanelObject},
            };
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
    }
}