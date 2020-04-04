using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Scenario : MonoBehaviour
    {
        [SerializeField]
        private string _scenarioStartDate;

        [SerializeField]
        private int _startingMoney;

        public string ScenarioStartDate { get => _scenarioStartDate; set => _scenarioStartDate = value; }
        public int StartingMoney { get => _startingMoney; set => _startingMoney = value; }
    }
}