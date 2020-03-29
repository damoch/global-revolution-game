using Assets.Scripts.State;
using Assets.Scripts.World;
using Assets.Scripts.UI;
using System.Text;
using UnityEngine;
using Assets.Scripts.Data;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private WorldState _worldState;

        [SerializeField]
        private UiController _uiController;

        [SerializeField]
        private Country[] _countries;

        [SerializeField]
        private BaseController _baseController;
        
        private Rules _rules;
        private Scenario _scenario;
        private GamePlayState _gamePlayState;
        public Rules Rules { get => _rules; set => _rules = value; }
        public BaseController BaseController { get => _baseController; set => _baseController = value; }

        private void Start()
        {
            Debug.Log(GetAboutString());
            _rules = GetComponent<Rules>();
            _scenario = GetComponent<Scenario>();
            _gamePlayState = GamePlayState.WorldMap;
            _uiController.ChangeView(_gamePlayState);

            SetUpScenario();
            _worldState.GameClock.OnMinutePassed += _uiController.UpdateClockValue;
            _worldState.GameClock.OnMinutePassed += _baseController.UpdateBaseState;

            InjectToOthers();
        }

        private void SetUpScenario()
        {
            _worldState.GameClock.SetStartupDate(_scenario.ScenarioStartDate);
        }

        private void InjectToOthers()
        {
            _baseController.InjectController(this);
            _uiController.InjectController(this);
            
            foreach (var country in _countries)
            {
                country.InjectGameCotroller(this);
            }
        }

        public string GetAboutString()
        {
            var sb = new StringBuilder();
            sb.Append(Application.productName);
            sb.Append(" by ");
            sb.Append(Application.companyName);
            sb.Append("\nVersion: ");
            sb.Append(Application.version);
            sb.Append("\nBUILD NO:");
            sb.Append(Application.buildGUID);

            return sb.ToString();
        }

        public void ChangeGamePlayState()
        {
            if(_gamePlayState == GamePlayState.WorldMap)
            {
                _gamePlayState = GamePlayState.BaseView;
                _worldState.GameClock.SetClockRunning(false);
            }
            else if(_gamePlayState == GamePlayState.BaseView)
            {
                _gamePlayState = GamePlayState.WorldMap;
                _worldState.GameClock.SetClockRunning(true);
            }
            _uiController.ChangeView(_gamePlayState);
        }
    }
}
