using UnityEngine;

namespace Assets.Scripts.State
{
    public class BaseState : MonoBehaviour
    {
        [SerializeField]
        private int _money;

        public int Money { get => _money; set => _money = value; }
    }

}