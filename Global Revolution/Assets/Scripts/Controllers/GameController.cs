using Assets.Scripts.State;
using Assets.Scripts.UI;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private WorldState _worldState;

        [SerializeField]
        private UiController _uiController;

        private void Start()
        {
            Debug.Log(GetAboutString());

            _worldState.GameClock.OnMinutePassed += _uiController.UpdateClockValue;
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
    }
}
