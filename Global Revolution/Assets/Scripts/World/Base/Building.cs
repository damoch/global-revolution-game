using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class Building : MonoBehaviour
    {
        [SerializeField]
        private int _constructionCost;

        [SerializeField]
        private int _hourlyMoneyBalance;

        [SerializeField]
        private int _energyBalance;
        
        [SerializeField]
        private int _buildTimeInMinutes;

        [SerializeField]
        private string _inGameName;

        public int BuildTimeInMinutes { get => _buildTimeInMinutes; }
        public int ConstructionCost { get => _constructionCost; }
        public string InGameName { get => _inGameName; }
    }
}
