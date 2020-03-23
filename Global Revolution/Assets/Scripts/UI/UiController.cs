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

        private GameController _gameController;

        public void UpdateClockValue(DateTime currentDate)
        {
            _clockText.text = currentDate.ToString();
            _moneyText.text = _gameController.BaseController.BaseState.Money.ToString();
        }

        public void ChangeView(GamePlayState currentState)
        {
            if(currentState == GamePlayState.WorldMap)
            {
                _camera.transform.position = _cameraPositionWorld;
            }
            else if(currentState == GamePlayState.BaseView)
            {
                _camera.transform.position = _cameraPositionBase;
            }
        }

        public void InjectController(GameController gameController)
        {
            _gameController = gameController;
        }
    }
}
