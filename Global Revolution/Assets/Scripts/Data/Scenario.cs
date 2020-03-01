using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Scenario : MonoBehaviour
    {
        [SerializeField]
        private string _scenarioStartDate;

        public string ScenarioStartDate { get => _scenarioStartDate; set => _scenarioStartDate = value; }
    }
}