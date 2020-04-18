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
        private Text _energyBalanceText;

        [SerializeField]
        private BaseControlPanelController _baseControlPanel;

        [SerializeField]
        private WorldPanelController _worldPanelController;

        private GameController _gameController;
        private UiStrings _uiStrings;

        public WorldPanelController WorldPanelController { get => _worldPanelController; }

        public void UpdateClockValue(DateTime currentDate)
        {
            _clockText.text = currentDate.ToString();
            UpdateBaseData();
        }

        public void UpdateBaseData()
        {
            _moneyText.text = string.Format(_uiStrings.MoneyValueFormat, _gameController.BaseController.BaseState.Money.ToString());
            _energyBalanceText.text = string.Format(_uiStrings.EnergyValueFormat,_gameController.BaseController.BaseState.EnergyBalance.ToString());
        }

        public void ChangeView(GamePlayState currentState)
        {
            if(currentState == GamePlayState.WorldMap)
            {
                _camera.transform.position = _cameraPositionWorld;
                _baseControlPanel.gameObject.SetActive(false);
                _worldPanelController.gameObject.SetActive(true);
                _changeSteteButtonText.text = _uiStrings.BaseViewText;
            }
            else if(currentState == GamePlayState.BaseView)
            {
                _camera.transform.position = _cameraPositionBase;
                _baseControlPanel.gameObject.SetActive(true);
                _worldPanelController.gameObject.SetActive(false);
                _baseControlPanel.ActivatePanel(BasePanelState.Main);
                _changeSteteButtonText.text = _uiStrings.WorldViewText;
            }
        }

        public void InjectController(GameController gameController)
        {
            _uiStrings = GetComponent<UiStrings>();
            _gameController = gameController;

            _baseControlPanel.InjectAvailableBuildings(gameController.Rules.AvailableBaseBuildings, 
            _gameController.BaseController, this);
        }
    }
}
