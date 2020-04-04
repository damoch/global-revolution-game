using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.State;
using Assets.Scripts.Controllers;

namespace Assets.Scripts.UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private Text _clockText;

        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Vector3 _cameraPositionWorld;
        
        [SerializeField]
        private Vector3 _cameraPositionBase;

        [SerializeField]
        private Text _changeSteteButtonText;

        [SerializeField]
        private Text _moneyText;

        [SerializeField]
        private BaseControlPanelController _baseControlPanel;

        private GameController _gameController;

        public void UpdateClockValue(DateTime currentDate)
        {
            _clockText.text = currentDate.ToString();
            UpdateBaseData();
        }

        public void UpdateBaseData()
        {
            _moneyText.text = _gameController.BaseController.BaseState.Money.ToString();
        }

        public void ChangeView(GamePlayState currentState)
        {
            if(currentState == GamePlayState.WorldMap)
            {
                _camera.transform.position = _cameraPositionWorld;
                _baseControlPanel.gameObject.SetActive(false);
            }
            else if(currentState == GamePlayState.BaseView)
            {
                _camera.transform.position = _cameraPositionBase;
                _baseControlPanel.gameObject.SetActive(true);
                _baseControlPanel.ActivatePanel(BasePanelState.Main);
            }
        }

        public void InjectController(GameController gameController)
        {
            _gameController = gameController;

            _baseControlPanel.InjectAvailableBuildings(gameController.Rules.AvailableBaseBuildings, 
            _gameController.BaseController, this);
        }
    }
}
