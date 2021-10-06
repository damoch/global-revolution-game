using Assets.Scripts.Data.Enum;
using Assets.Scripts.State;
using Assets.Scripts.World;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Data.Factories
{
    public class ContractFactory : MonoBehaviour
    {
        private static Rules _rules;
        private static WorldState _worldState;

        public static Contract CreateContractFor(Corporation corporation)
        {
            //TODO: propper implementation
            var contract = new Contract();
            var target = _worldState.CityBuildings.FirstOrDefault(x => corporation.HostileCorporations.Contains(x.Owner));

            if(target == null)
            {
                return null;
            }

            contract.Target = target;
            contract.ContractType = ContractType.Destroy;

            return contract;
        }

        internal void SetRulesAndState(Rules rules, WorldState worldState)
        {
            _rules = rules;
            _worldState = worldState;
        }
    }
}
