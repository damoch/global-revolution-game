using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class CityBuilding : MonoBehaviour, IContractTarget
    {
        public CityBuildingType BuildingType;
        public Corporation Owner;
        public bool IsDestroyed;
    }
}
