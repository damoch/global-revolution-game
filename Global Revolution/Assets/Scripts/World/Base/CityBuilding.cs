using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class CityBuilding : MonoBehaviour
    {
        public CityBuildingType BuildingType;
        public Corporation Owner;
        public bool IsDestroyed;
    }
}
