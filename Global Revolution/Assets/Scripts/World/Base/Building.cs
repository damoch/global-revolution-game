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
    }
}
