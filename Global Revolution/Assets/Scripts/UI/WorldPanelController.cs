using UnityEngine;

namespace Assets.Scripts.UI
{
    public class WorldPanelController : MonoBehaviour
    {
        [SerializeField]
        private GameLogController _gameLogController;

        public GameLogController GameLogController { get => _gameLogController;  }
    }
    
}