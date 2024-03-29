﻿using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class CityBuilding : MonoBehaviour, IContractTarget
    {
        public CityBuildingType BuildingType;
        public Corporation Owner;
        public bool IsDestroyed;

        public string TargetName { get => BuildingType.ToString(); }

        public Corporation TargetOwner => Owner;

        public City City { get; internal set; }
    }
}
