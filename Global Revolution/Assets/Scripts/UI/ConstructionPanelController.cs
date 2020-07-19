using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Scripts.World.Base;
using Assets.Scripts.State;
using System;

namespace Assets.Scripts.UI
{    public class ConstructionPanelController : MonoBehaviour
    {
        public Dictionary<Button, Building> ButtonToBuilding { get; set; }     

        public BaseState BaseState { get; set; } 

        private void OnEnable()
        {
            CheckWhatCanBeBuilt();
        }

        internal void CheckWhatCanBeBuilt()
        {
            foreach (var item in ButtonToBuilding)
            {
                item.Key.interactable = item.Value.ConstructionCost <= BaseState.Money;
            }
        }
    }
}
