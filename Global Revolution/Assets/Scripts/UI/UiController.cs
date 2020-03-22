using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.State;

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

        public void UpdateClockValue(DateTime currentDate)
        {
            _clockText.text = currentDate.ToString();
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
    }
}
