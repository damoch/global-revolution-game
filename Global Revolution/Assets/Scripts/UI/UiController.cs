using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        private Text _clockText;
        public void UpdateClockValue(DateTime currentDate)
        {
            _clockText.text = currentDate.ToString();
        }
    }
}
