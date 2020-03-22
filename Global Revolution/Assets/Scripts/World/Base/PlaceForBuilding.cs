using UnityEngine;

namespace Assets.Scripts.World.Base
{
    public class PlaceForBuilding : MonoBehaviour
    {
        [SerializeField]
        private Building _building;

        private void Start()
        {
            if(_building != null){
                _building.gameObject.transform.position = transform.position;
            }

        }
    }
}