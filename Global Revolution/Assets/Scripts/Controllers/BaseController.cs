using System;
using Assets.Scripts.State;
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
            // _clockText.text = currentDate.ToString();
        }

        public void InjectController(GameController contr)
        {
            _gameController = contr;
        }
    }
}