using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UiStrings:MonoBehaviour
    {
        [SerializeField]
        private string _moneyValueFormat;

        [SerializeField]
        private string _energyValueFormat;

        [SerializeField]
        private string _worldViewText;

        [SerializeField]
        private string _baseViewText;

        public string MoneyValueFormat { get => _moneyValueFormat; }
        public string EnergyValueFormat { get => _energyValueFormat; }
        public string WorldViewText { get => _worldViewText; }
        public string BaseViewText { get => _baseViewText; }
    }
}